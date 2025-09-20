using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnSettingsButtonClick()
    {
        UIManager.instance.settings.SetActive(true);
    }
    public void OnSettingCloseButtonClick()
    {
        UIManager.instance.settings.SetActive(false);
    }

    public void OnRecipesButtonClick()
    {
        UIManager.instance.recipes.SetActive(true);
    }
    public void OnRecipesCloseButtonClick()
    {
        UIManager.instance.recipes.SetActive(false);
    }

    public void OnShopButtonClick()
    {
        UIManager.instance.shop.SetActive(true);
    }
    public void OnShopCloseButtonClick()
    {
        UIManager.instance.shop.SetActive(false);
    }

    public void OnCahRegisterButtonClick()
    {
        Camera.main.transform.position = new Vector3(0, 0.6f, -6.2f);
        UIManager.instance.cashRegisterUI.SetActive(false);
        UIManager.instance.coffee.SetActive(false);
        UIManager.instance.cupcakes.SetActive(false);
        UIManager.instance.coffeeMakingTime.SetActive(false);
    }

    public void OnCupBoardCornerClick() 
    { 
        ShopManager.instance.price = 100; 
        ShopManager.instance.Buy(ObjectManager.instance.cupBoadCorner); 
    }
    public void OnEspressoMachineClick() 
    { 
        ShopManager.instance.price = 50; 
        ShopManager.instance.Buy(ObjectManager.instance.espressoMachine); 
    }
    public void OnCashRegisterClick() 
    { 
        ShopManager.instance.price = 50; 
        ShopManager.instance.Buy(ObjectManager.instance.cashRegister); 
    }
    public void OnCupBoardNarrowClick() { 
        ShopManager.instance.price = 150; 
        ShopManager.instance.Buy(ObjectManager.instance.cupBoardNarrow); 
    }
    public void OnCupBoard01Click() 
    { 
        ShopManager.instance.price = 250;
        ShopManager.instance.Buy(ObjectManager.instance.cupBoard01); 
    }
    public void OnCupBoard02Click() 
    { ShopManager.instance.price = 300; 
        ShopManager.instance.Buy(ObjectManager.instance.cupBoard02); 
    }
    public void OnStoveClick() 
    { 
        ShopManager.instance.price = 500; 
        ShopManager.instance.Buy(ObjectManager.instance.stove); 
    }
}


