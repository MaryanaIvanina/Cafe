using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject settings;
    public GameObject recipes;
    public GameObject shop;
    public void OnPlayButtonClick()
    {         
        SceneManager.LoadScene("Loading");
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
}
