using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    [Header("Налаштування файлу")]
    public string fileName = "save.json";

    [Header("Менеджери")]
    public InventoryManager inventoryManager;

    [Header("Префаби купованих об'єктів")]
    public List<PrefabEntry> purchasablePrefabs = new List<PrefabEntry>();

    [Header("База страв")]
    public List<DishEntry> dishDatabase = new List<DishEntry>();

    public Transform purchasedParent;

    private string FullPath;

    private void Awake()
    {
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }

        FullPath = Path.Combine(Application.persistentDataPath, fileName);
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }
    private void OnApplicationPause(bool pause) 
    { 
        if (pause) Save(); 
    }

    #region API
    public void Save()
    {
        SaveData sd = new SaveData();

        sd.currentMoney = MoneyManager.Instance != null ? MoneyManager.Instance.GetCurrentMoney() : 0;
        sd.score = Score.Instance != null ? Score.Instance.score : 0;
        sd.level = Score.Instance != null ? Score.Instance.GetLevel() : 1;

        sd.inventorySellPrices = inventoryManager != null ? inventoryManager.GetInventorySellPrices() : new List<int>();
        sd.dishCount = inventoryManager != null ? inventoryManager.dishCount : 0;

        sd.purchasedObjects = new List<PurchasedObjectData>();
        Purchasable[] all = FindObjectsOfType<Purchasable>();
        foreach (var p in all)
        {
            PurchasedObjectData pod = new PurchasedObjectData();
            pod.id = string.IsNullOrEmpty(p.id) ? p.gameObject.name : p.id;
            Vector3 pos = p.transform.position;
            pod.px = pos.x; pod.py = pos.y; pod.pz = pos.z;
            Quaternion r = p.transform.rotation;
            pod.rx = r.x; pod.ry = r.y; pod.rz = r.z; pod.rw = r.w;
            pod.active = p.gameObject.activeSelf;
            IsBusy isBusy = p.GetComponent<IsBusy>();
            if (isBusy == null)
                pod.isBusy = false;
            else
                pod.isBusy = p.GetComponent<IsBusy>().isBusy;
            sd.purchasedObjects.Add(pod);
        }

        try
        {
            string json = JsonUtility.ToJson(sd, true);
            File.WriteAllText(FullPath, json);
        }
        catch (Exception e)
        {
            Debug.LogError($"SaveManager: Save error: {e}");
        }
    }

    public void Load()
    {
        if (!File.Exists(FullPath))
        {
            return;
        }

        try
        {
            string json = File.ReadAllText(FullPath);
            SaveData sd = JsonUtility.FromJson<SaveData>(json);
            if (sd == null) return; 

            if (MoneyManager.Instance != null) MoneyManager.Instance.SetMoney(sd.currentMoney);
            if (Score.Instance != null)
            {
                Score.Instance.SetScore(sd.score);
                Score.Instance.SetLevel(sd.level); 
            }

            if (inventoryManager != null)
            {
                inventoryManager.ClearInventory();
                if (sd.inventorySellPrices != null)
                {
                    foreach (int price in sd.inventorySellPrices)
                    {
                        var entry = dishDatabase.Find(d => d.sellPrice == price);
                        if (entry != null)
                            inventoryManager.AddItem(entry.icon, entry.sellPrice);
                    }
                    inventoryManager.dishCount = sd.dishCount;
                }
            }

            if (sd.purchasedObjects != null)
            {
                foreach (var pod in sd.purchasedObjects)
                {
                    Purchasable found = FindPurchasableById(pod.id);
                    if (found != null)
                    {
                        found.transform.position = new Vector3(pod.px, pod.py, pod.pz);
                        found.transform.rotation = new Quaternion(pod.rx, pod.ry, pod.rz, pod.rw);
                        if (pod.isBusy)
                        {
                            var timer = found.GetComponent<TimerActivator>().cookingTimer;
                            timer.GetReady();
                            timer.gameObject.SetActive(true);
                        }

                        found.gameObject.SetActive(pod.active);
                    }
                    else
                    {
                        var prefabEntry = purchasablePrefabs.Find(pe => pe.id == pod.id);
                        if (prefabEntry != null && prefabEntry.prefab != null)
                        {
                            GameObject go = Instantiate(prefabEntry.prefab,
                                new Vector3(pod.px, pod.py, pod.pz),
                                new Quaternion(pod.rx, pod.ry, pod.rz, pod.rw),
                                purchasedParent);
                            go.SetActive(pod.active);
                            Purchasable pcomp = go.GetComponent<Purchasable>();
                            if (pcomp == null) pcomp = go.AddComponent<Purchasable>();
                            pcomp.id = pod.id;
                            go.name = pod.id;
                        }
                    }
                }
            }

            Debug.Log("SaveManager: Load complete.");
        }
        catch (Exception e)
        {
            Debug.LogError($"SaveManager: Load error: {e}");
        }
    }
    #endregion

    #region helpers
    private Purchasable FindPurchasableById(string id)
    {
        if (string.IsNullOrEmpty(id)) return null;
        Purchasable[] all = FindObjectsOfType<Purchasable>();
        foreach (var p in all) if (p.id == id) return p;
        return null;
    }
    #endregion

    #region data classes
    [Serializable]
    public class PrefabEntry
    {
        public string id;
        public GameObject prefab;
    }

    [Serializable]
    public class DishEntry
    {
        public string id;
        public Sprite icon;
        public int sellPrice;
    }

    [Serializable]
    public class SaveData
    {
        public int currentMoney;
        public int score;
        public int level;
        public List<int> inventorySellPrices;
        public int dishCount;
        public List<PurchasedObjectData> purchasedObjects;
    }

    [Serializable]
    public class PurchasedObjectData
    {
        public string id;
        public float px, py, pz;
        public float rx, ry, rz, rw;
        public bool active;
        public bool isBusy;
    }
    #endregion
}
