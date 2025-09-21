using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public Transform contentParent;

    public GameObject inventoryItemPrefab;

    private List<InventoryItemData> inventory = new List<InventoryItemData>();
    private List<GameObject> itemUIObjects = new List<GameObject>();

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void AddItem(Sprite icon, int sellPrice)
    {
        InventoryItemData newItem = new InventoryItemData
        {
            icon = icon,
            sellPrice = sellPrice
        };
        inventory.Add(newItem);

        CreateItemUI(newItem);
    }

    private void CreateItemUI(InventoryItemData itemData)
    {
        if (inventoryItemPrefab == null || contentParent == null)
        {
            Debug.LogWarning("InventoryManager: prefab або contentParent не вказані.");
            return;
        }

        GameObject go = Instantiate(inventoryItemPrefab, contentParent);
        InventoryItemDisplay itemDisplay = go.GetComponent<InventoryItemDisplay>();

        if (itemDisplay == null)
            itemDisplay = go.AddComponent<InventoryItemDisplay>();

        itemDisplay.Initialize(itemData);
        itemUIObjects.Add(go);
    }

    public bool TryFulfillOrder(int requiredPrice)
    {
        InventoryItemData foundItem = null;
        GameObject foundUIObject = null;
        int foundIndex = -1;

        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].sellPrice == requiredPrice)
            {
                foundItem = inventory[i];
                foundUIObject = itemUIObjects[i];
                foundIndex = i;
                break;
            }
        }

        if (foundItem != null)
        {
            // Видаляємо айтем з інвентаря
            inventory.RemoveAt(foundIndex);
            itemUIObjects.RemoveAt(foundIndex);
            Destroy(foundUIObject);

            Debug.Log($"Айтем з ціною {requiredPrice} видалено з інвентаря.");
            return true;
        }

        return false;
    }

    // Метод для перевірки кількості айтемів (опціонально)
    public int GetItemCount()
    {
        return inventory.Count;
    }

    // Метод для перевірки чи є айтем з певною ціною (опціонально)
    public bool HasItemWithPrice(int price)
    {
        foreach (var item in inventory)
        {
            if (item.sellPrice == price)
                return true;
        }
        return false;
    }
}

