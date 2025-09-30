using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public Transform contentParent;
    public GameObject inventoryItemPrefab;

    private List<InventoryItemData> inventory = new List<InventoryItemData>();
    private List<GameObject> itemUIObjects = new List<GameObject>();
    public List<int> GetInventorySellPrices()
    {
        List<int> list = new List<int>();
        foreach (var item in inventory)
            list.Add(item.sellPrice);
        return list;
    }

    public void ClearInventory()
    {
        foreach (var go in itemUIObjects)
            if (go != null) Destroy(go);
        itemUIObjects.Clear();
        inventory.Clear();
        dishCount = 0;
    }



    public int dishCount = 0;

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
        if (inventoryItemPrefab == null || contentParent == null) return;

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
            inventory.RemoveAt(foundIndex);
            itemUIObjects.RemoveAt(foundIndex);
            Destroy(foundUIObject);

            return true;
        }

        return false;
    }

    public int GetItemCount()
    {
        return inventory.Count;
    }

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

