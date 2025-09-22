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
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
    }

    public void OnSettingsButtonClick()
    {
        UIManager.instance.settings.SetActive(true);
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
    }
    public void OnSettingCloseButtonClick()
    {
        UIManager.instance.settings.SetActive(false);
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
    }

    public void OnRecipesButtonClick()
    {
        UIManager.instance.recipes.SetActive(true);
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
    }
    public void OnRecipesCloseButtonClick()
    {
        UIManager.instance.recipes.SetActive(false);
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
    }

    public void OnShopButtonClick()
    {
        UIManager.instance.shop.SetActive(true);
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
    }
    public void OnShopCloseButtonClick()
    {
        UIManager.instance.shop.SetActive(false);
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
    }

    public void OnCahRegisterButtonClick()
    {
        Camera.main.transform.position = new Vector3(0, 0.6f, -6.2f);
        UIManager.instance.cashRegisterUI.SetActive(false);
        UIManager.instance.coffee.SetActive(false);
        UIManager.instance.cupcakes.SetActive(false);
        UIManager.instance.cookingTime.SetActive(false);
        UIManager.instance.shopButton.SetActive(true);
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
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
    public void OnNextLevelClick()
    {
        UIManager.instance.levelUp.SetActive(false);
        Score.Instance.GoToTheNextLevel();
        AudioManager.instance.PlaySFX(AudioManager.instance.buttonClick);
    }
}


