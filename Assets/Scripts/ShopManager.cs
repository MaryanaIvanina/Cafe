using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public int price;

    public static ShopManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void Buy(GameObject obj)
    {
        if (MoneyManager.Instance.currentMoney - price < 0) return;
        MoneyManager.Instance.SpendMoney(price);
        UIManager.instance.shop.SetActive(false);
        ObjectManager.instance.PutObject(obj);
        SaveManager.instance.Save();
    }
}
