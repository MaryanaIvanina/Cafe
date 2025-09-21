using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.Serialization;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI levelNumber;
    public int score = 0;
    private int neededScore = 10;
    private int level = 1;
    private int reward = 100;
    public static Score Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void Update()
    {
        if(score == neededScore)
            ObjectManager.instance.levelUp.SetActive(true);
    }
    private void UpdateUI()
    {
        levelNumber.text = "Level" + level.ToString();
    }
    public void GoToTheNextLevel()
    {
        level++;
        UpdateUI();
        score = 0;
        AddLevelFeatures();
    }
    private void AddLevelFeatures()
    {
        if (level == 2)
        {
            ObjectManager.instance.cupBoarNarrowHiding.SetActive(false);
            ObjectManager.instance.cupBoar01Hiding.SetActive(false);
            ObjectManager.instance.milkButtonHiding.SetActive(false);
            ObjectManager.instance.latteInMenu.SetActive(true);
            OrderManager.instance.allPossibleDishes.Add(ObjectManager.instance.latte);
            ObjectManager.instance.milkButtonHiding.SetActive(false);
            MoneyManager.Instance.AddMoney(reward);
            neededScore = 20;
        }
        if (level == 3)
        {
            ObjectManager.instance.cupBoar02Hiding.SetActive(false);
            ObjectManager.instance.stoveHiding.SetActive(false);
            ObjectManager.instance.cupcakesInMenu.SetActive(true);
            OrderManager.instance.allPossibleDishes.Add(ObjectManager.instance.chocolateCupcake);
            OrderManager.instance.allPossibleDishes.Add(ObjectManager.instance.cherryCupcake);
            OrderManager.instance.allPossibleDishes.Add(ObjectManager.instance.oreoCupcake);
            MoneyManager.Instance.AddMoney(reward * 2);
            neededScore = 30;
        }
    }
}
