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
    public GameObject shopButton;
    public GameObject cupBoarNarrowHiding;
    public GameObject cupBoar01Hiding;
    public GameObject cupBoar02Hiding;
    public GameObject stoveHiding;
    public GameObject milkButtonHiding;
    public GameObject latteInMenu;
    public GameObject cupcakesInMenu;
    public GameObject levelUp;
    public GameObject goToStove;
    public GameObject goToEspressoMachine;

    public static UIManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
}
