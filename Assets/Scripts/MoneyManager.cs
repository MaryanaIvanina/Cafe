using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    [Header("UI")]
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI shopMoneyText;

    [Header("Starting Money")]
    public int startingMoney = 400;

    private int currentMoney;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        currentMoney = startingMoney;
        UpdateUI();
    }

    public int GetCurrentMoney()
    {
        return currentMoney;
    }

    public void AddMoney(int amount)
    {
        Debug.Log($"currentMoney {currentMoney}, amount {amount}");
        if (amount < 0) return;
        currentMoney += amount;
        Score.Instance.score++;
        UpdateUI();
    }

    public void SpendMoney(int amount)
    {
        if (amount < 0 || currentMoney < amount) return;

        currentMoney -= amount;
        Score.Instance.score++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (moneyText != null)
        {
            moneyText.text = currentMoney.ToString();
            shopMoneyText.text = currentMoney.ToString();
        }
    }
}