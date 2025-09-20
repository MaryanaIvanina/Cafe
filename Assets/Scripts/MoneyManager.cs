using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public TextMeshProUGUI money;

    void Update()
    {
        money.text = ShopManager.instance.moneyCount.ToString();
    }
}
