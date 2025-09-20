using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeMachineManager : Cooking
{
    [Header("Cups")]
    public GameObject espressoCup;
    public GameObject americanoCup;
    public GameObject latteCup;

    [Header("References")]
    public GameObject espressoMachine;
    public Slider cookingTime;

    public GameObject firstButton;
    public GameObject secondButton;
    public GameObject thirdButton;

    public float progress = 0;
    public bool isLoadFinished = false;
    private bool isCooking = false;
    private CookingUI firstButtonUI;
    private CookingUI secondButtonUI;
    private CookingUI thirdButtonUI;

    private float cookingDuration;

    private void Start()
    {
        firstButtonUI = firstButton.GetComponent<CookingUI>();
        secondButtonUI = secondButton.GetComponent<CookingUI>();
        thirdButtonUI = thirdButton.GetComponent<CookingUI>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ObjectManager.instance.transformMode)
        {
            if (IsMachineSelected("espressoMachine"))
            {
                Cook(selectedMachine, new Vector3(-0.5f, 0.3f, -1.5f), UIManager.instance.coffee);
            }
        }
        if (Input.GetMouseButtonDown(0) && !isCooking)
        {
            if (IsMachineSelected("espressoMachine") && IsValideRecipe())
            {
                isCooking = true;
                StartCoroutine(MakeCoffe());
            }
            else if (IsMachineSelected("espressoMachine") && !IsValideRecipe())
            {
                firstButtonUI.isPressed = false;
                secondButtonUI.isPressed = false;
                thirdButtonUI.isPressed = false;
            }
        }
    }

    IEnumerator MakeCoffe()
    {
        GameObject cup = null;
        if (!secondButtonUI.isPressed && !thirdButtonUI.isPressed)
        {
            cup = espressoCup;
            cookingDuration = 0.9f;
        }
        else if (secondButtonUI.isPressed && !thirdButtonUI.isPressed)
        {
            cup = americanoCup;
            cookingDuration = 0.5f;
        }
        else if (secondButtonUI.isPressed && thirdButtonUI.isPressed)
        {
            cup = latteCup;
            cookingDuration = 0.3f;
        }
        else
        {
            firstButtonUI.isPressed = false;
            secondButtonUI.isPressed = false;
            thirdButtonUI.isPressed = false;
        }

        firstButtonUI.isPressed = false;
        secondButtonUI.isPressed = false;
        thirdButtonUI.isPressed = false;

        if (cup != null)
        {
            cup.SetActive(true);
            cup.transform.position = selectedMachine.transform.position;
        }

        progress = 0f;
        cookingTime.value = 0;
        UIManager.instance.coffeeMakingTime.SetActive(true);
        isLoadFinished = false;

        while (!isLoadFinished)
        {
            LoadSlider();
            yield return null;
        }

        UIManager.instance.coffeeMakingTime.SetActive(false);
        cup.SetActive(false);
        isCooking = false;
    }

    private void LoadSlider()
    {
        progress += cookingDuration * Time.deltaTime;
        cookingTime.value = progress;
        if (cookingTime.value >= 1)
            isLoadFinished = true;
    }
    private bool IsValideRecipe()
    {
        if (firstButtonUI.isPressed && !secondButtonUI.isPressed && !thirdButtonUI.isPressed)
            return true;
        else if (firstButtonUI.isPressed && secondButtonUI.isPressed && !thirdButtonUI.isPressed)
            return true;
        else if (firstButtonUI.isPressed && secondButtonUI.isPressed && thirdButtonUI.isPressed)
            return true;
        return false;
    }
}

