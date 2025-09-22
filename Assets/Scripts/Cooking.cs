using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Cooking : MonoBehaviour
{
    protected GameObject selectedMachine;

    [Header("References")]
    public Slider cookingTime;

    public GameObject firstButton;
    public GameObject secondButton;
    public GameObject thirdButton;

    protected CookingUI firstButtonUI;
    protected CookingUI secondButtonUI;
    protected CookingUI thirdButtonUI;

    private float progress = 0;
    private bool isLoadFinished = false;
    protected bool isCooking = false;

    protected string machineTag;
    protected Vector3 offset;
    protected GameObject cookingUI;
    private GameObject readyDish = null;

    protected float cookingDuration;
    protected virtual void Start()
    {
        selectedMachine = null;

        firstButtonUI = firstButton.GetComponent<CookingUI>();
        secondButtonUI = secondButton.GetComponent<CookingUI>();
        thirdButtonUI = thirdButton.GetComponent<CookingUI>();
    }
    protected virtual void Update()
    {
        GoToCook();
        TryToCook();
        if (InventoryManager.instance.dishCount < 5 && readyDish != null)
        {
            FinishCooking(readyDish);
            readyDish = null;
        }
    }
    private void GoToCook()
    {
        if (Input.GetMouseButtonDown(0) && !ObjectManager.instance.transformMode)
            if (IsMachineSelected(machineTag)) Cook(selectedMachine, offset, cookingUI);
    }
    private void TryToCook()
    {
        if (Input.GetMouseButtonDown(0) && !isCooking)
        {
            if (IsMachineSelected(machineTag) && IsValidRecipe())
            {
                isCooking = true;
                ReadRecipe();
            }
            else if (IsMachineSelected(machineTag) && !IsValidRecipe())
                DefaultButtons();
        }
    }
    protected bool IsMachineSelected(string machineTag)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.CompareTag(machineTag))
            {
                selectedMachine = hit.transform.gameObject;
                return true;
            }
        }
        return false;
    }
    public void Cook(GameObject machine, Vector3 offset, GameObject UI)
    {
        Camera.main.transform.position = machine.transform.position + offset;
        UI.SetActive(true);
        UIManager.instance.cashRegisterUI.SetActive(true);
        UIManager.instance.shopButton.SetActive(false);
    }
    abstract protected void ReadRecipe();
    protected virtual void DefaultButtons()
    {
        firstButtonUI.isPressed = false;
        secondButtonUI.isPressed = false;
        thirdButtonUI.isPressed = false;
    }
    protected abstract bool IsValidRecipe();
    protected void CookDish(GameObject dish, float cookingDuration)
    {
        ShowDish(dish);
        StartCooking();
        StartCoroutine(CookingProcess(dish, cookingDuration));
    }
    private IEnumerator CookingProcess(GameObject dish, float cookingDuration)
    {
        yield return StartCoroutine(Cook(cookingDuration));
        FinishCooking(dish);
    }

    protected virtual void ShowDish(GameObject dish)
    {
        dish.SetActive(true);
        dish.transform.position = new Vector3(selectedMachine.transform.position.x, selectedMachine.transform.position.y + 0.6f, selectedMachine.transform.position.z - 0.3f);
    }
    protected void StartCooking()
    {
        progress = 0f;
        cookingTime.value = 0;
        isLoadFinished = false;
        UIManager.instance.cookingTime.SetActive(true);
    }
    IEnumerator Cook(float cookingDuration)
    {
        while (!isLoadFinished)
        {
            LoadSlider(cookingDuration);
            yield return null;
        }
    }
    protected void LoadSlider(float cookingDuration)
    {
        progress += cookingDuration * Time.deltaTime;
        cookingTime.value = progress;
        if (cookingTime.value >= 1)
            isLoadFinished = true;
    }
    protected void FinishCooking(GameObject dish)
    {
        UIManager.instance.cookingTime.SetActive(false);
        if (InventoryManager.instance.dishCount == 5) 
        {
            readyDish = dish;
            return;
        }
        Dish dishData = dish.GetComponent<Dish>();
        if (dishData != null)
        {
            if (InventoryManager.instance != null)
                InventoryManager.instance.AddItem(dishData.icon, dishData.sellPrice);
        }

        dish.SetActive(false);
        isCooking = false;
        InventoryManager.instance.dishCount++;
    }

}







