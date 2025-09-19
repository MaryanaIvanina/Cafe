using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Buttons : ObjectManager
{
    private void BuyingObject()
    {
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
        BuyingObject();
    }
    public void OnEspressoMachineClick()
    {
        selectedObject = espressoMachine;
        BuyingObject();
    }
    public void OnCashRegisterClick()
    {
        selectedObject = cashRegister;
        BuyingObject();
    }
    public void OnCupBoardNarrowClick()
    {
        selectedObject = cupBoardNarrow;
        BuyingObject();
    }
    public void OnCupBoard01Click()
    {
        selectedObject = cupBoard01;
        BuyingObject();
    }
    public void OnCupBoard02Click()
    {
        selectedObject = cupBoard02;
        BuyingObject();
    }
    public void OnStoveClick()
    {
        selectedObject = stove;
        BuyingObject();
    }
}

