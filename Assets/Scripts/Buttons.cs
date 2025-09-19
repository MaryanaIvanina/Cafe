using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Buttons : ObjectManager
{
    private void BuyingObject()
    {
        moneyCount -= price;
        OnShopCloseButtonClick();
        PutObject(selectedObject);
        transformMode = true;
    }
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
        settings.SetActive(true);
    }
    public void OnSettingCloseButtonClick()
    {         
        settings.SetActive(false);
    }
    public void OnRecipesButtonClick()
    {
        recipes.SetActive(true);
    }
    public void OnRecipesCloseButtonClick()
    {         
        recipes.SetActive(false);
    }
    public void OnShopButtonClick()
    {
        shop.SetActive(true);
    }
    public void OnShopCloseButtonClick()
    {         
        shop.SetActive(false);
    }
    public void OnCupBoardCornerClick()
    {
        selectedObject = cupBoadCorner;
        price = 100;
        BuyingObject();
    }
    public void OnEspressoMachineClick()
    {
        selectedObject = espressoMachine;
        price = 50;
        BuyingObject();
    }
    public void OnCashRegisterClick()
    {
        selectedObject = cashRegister;
        price = 50;
        BuyingObject();
    }
    public void OnCupBoardNarrowClick()
    {
        selectedObject = cupBoardNarrow;
        price = 150;
        BuyingObject();
    }
    public void OnCupBoard01Click()
    {
        selectedObject = cupBoard01;
        price = 250;
        BuyingObject();
    }
    public void OnCupBoard02Click()
    {
        selectedObject = cupBoard02;
        price = 300;
        BuyingObject();
    }
    public void OnStoveClick()
    {
        selectedObject = stove;
        price = 500;
        BuyingObject();
    }
}

