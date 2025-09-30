using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.Serialization;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI levelNumber;
    public int score = 0;
    private int neededScore = 2;
    public int level = 3;
    private int reward = 100;
    public static Score Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void Update()
    {
        if (score == neededScore)
        {
            UIManager.instance.levelUp.SetActive(true);
            AudioManager.instance.PlaySFX(AudioManager.instance.levelUp);
        }
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
        ApplyLevelState();
    }
    public void SetScore(int value)
    {
        score = value;
        UpdateUI();
    }

    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int value)
    {
        level = value;
        UpdateUI();
        ApplyLevelState(); 
    }

    public void ApplyLevelState()
    {
        if (level >= 2)
        {
            MoneyManager.Instance.AddMoney(reward);
            UIManager.instance.cupBoarNarrowHiding.SetActive(false);
            UIManager.instance.cupBoar01Hiding.SetActive(false);
            UIManager.instance.milkButtonHiding.SetActive(false);
            UIManager.instance.latteInMenu.SetActive(true);
            OrderManager.instance.allPossibleDishes.Add(ObjectManager.instance.latte);

            neededScore = 2;
        }
        if (level >= 3)
        {
            MoneyManager.Instance.AddMoney(reward*2);
            UIManager.instance.cupBoar02Hiding.SetActive(false);
            UIManager.instance.stoveHiding.SetActive(false);
            UIManager.instance.cupcakesInMenu.SetActive(true);
            OrderManager.instance.allPossibleDishes.Add(ObjectManager.instance.chocolateCupcake);
            OrderManager.instance.allPossibleDishes.Add(ObjectManager.instance.cherryCupcake);
            OrderManager.instance.allPossibleDishes.Add(ObjectManager.instance.oreoCupcake);

            neededScore = 3;
        }
    }

}
