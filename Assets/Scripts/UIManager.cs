using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject settings;
    public GameObject recipes;
    public GameObject shop;
    public GameObject cashRegisterUI;
    public GameObject coffee;
    public GameObject cupcakes;
    public GameObject coffeeButton;
    public GameObject sugarButton;
    public GameObject milkButton;
    public GameObject coffeeMakingTime;

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
}
