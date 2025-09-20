using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoveManager : Cooking
{
    [Header("Cupscakes")]
    public GameObject chocolateCupcake;
    public GameObject cherryCupcake;
    public GameObject oreoCupcake;
    public Slider cookingTime;

    public GameObject firstButton;
    public GameObject secondButton;
    public GameObject thirdButton;
    public GameObject fourthButton;

    public float progress = 0;
    public bool isLoadFinished = false;
    private bool isCooking = false;
    private CookingUI firstButtonUI;
    private CookingUI secondButtonUI;
    private CookingUI thirdButtonUI;
    private CookingUI fourthButtonUI;

    private float cookingDuration;

    private void Start()
    {
        firstButtonUI = firstButton.GetComponent<CookingUI>();
        secondButtonUI = secondButton.GetComponent<CookingUI>();
        thirdButtonUI = thirdButton.GetComponent<CookingUI>();
        fourthButtonUI = fourthButton.GetComponent<CookingUI>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ObjectManager.instance.transformMode)
        {
            if (IsMachineSelected("stove"))
            {
                Cook(selectedMachine, new Vector3(-0.5f, 0.8f, -2.3f), UIManager.instance.cupcakes);
            }
        }
        if (Input.GetMouseButtonDown(0) && !isCooking)
        {
            if (IsMachineSelected("stove") && IsValideRecipe())
            {
                isCooking = true;
                StartCoroutine(BackingCupcakes());
            }
            else if (IsMachineSelected("stove") && !IsValideRecipe())
            {
                firstButtonUI.isPressed = false;
                secondButtonUI.isPressed = false;
                thirdButtonUI.isPressed = false;
                fourthButtonUI.isPressed = false;
            }
        }
    }

    IEnumerator BackingCupcakes()
    {
        GameObject cupcake = null;
        if (firstButtonUI.isPressed && secondButtonUI.isPressed && !thirdButtonUI.isPressed && !fourthButtonUI.isPressed)
        {
            cupcake = chocolateCupcake;
            cookingDuration = 0.3f;
        }
        else if (firstButtonUI.isPressed && !secondButtonUI.isPressed && thirdButtonUI.isPressed && !fourthButtonUI.isPressed)
        {
            cupcake = cherryCupcake;
            cookingDuration = 0.1f;
        }
        else if (firstButtonUI.isPressed && !secondButtonUI.isPressed && !thirdButtonUI.isPressed && fourthButtonUI.isPressed)
        {
            cupcake = oreoCupcake;
            cookingDuration = 0.05f;
        }
        else
        {
            firstButtonUI.isPressed = false;
            secondButtonUI.isPressed = false;
            thirdButtonUI.isPressed = false;
            fourthButtonUI.isPressed = false;
        }

        firstButtonUI.isPressed = false;
        secondButtonUI.isPressed = false;
        thirdButtonUI.isPressed = false;
        fourthButtonUI.isPressed = false;

        if (cupcake != null)
        {
            cupcake.SetActive(true);
            cupcake.transform.position = new Vector3(selectedMachine.transform.position.x, selectedMachine.transform.position.y + 0.6f, selectedMachine.transform.position.z - 0.3f);
        }

        progress = 0f;
        cookingTime.value = 0;
        UIManager.instance.cookingTime.SetActive(true);
        isLoadFinished = false;

        while (!isLoadFinished)
        {
            LoadSlider();
            yield return null;
        }

        UIManager.instance.cookingTime.SetActive(false);
        cupcake.SetActive(false);
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
        if (firstButtonUI.isPressed && secondButtonUI.isPressed && !thirdButtonUI.isPressed && !fourthButtonUI.isPressed)
            return true;
        else if (firstButtonUI.isPressed && !secondButtonUI.isPressed && thirdButtonUI.isPressed && !fourthButtonUI.isPressed)
            return true;
        else if (firstButtonUI.isPressed && !secondButtonUI.isPressed && !thirdButtonUI.isPressed && fourthButtonUI.isPressed)
            return true;
        return false;
    }
}

