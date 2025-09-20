using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public int moneyCount = 400;
    public int price;

    public static ShopManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void Buy(GameObject obj)
    {
        moneyCount -= price;
        UIManager.instance.shop.SetActive(false);
        ObjectManager.instance.PutObject(obj);
    }
}
