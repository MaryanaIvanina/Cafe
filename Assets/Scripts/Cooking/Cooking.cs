using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Cooking : MonoBehaviour
{
    [Header("References")]
    public GameObject firstButton;
    public GameObject secondButton;
    public GameObject thirdButton;

    protected CookingUI firstButtonUI;
    protected CookingUI secondButtonUI;
    protected CookingUI thirdButtonUI;

    protected bool isCooking = false;
    private int machineNumber = 0;
    protected GameObject toEspressoMachineButton;
    protected GameObject toStoveButton;
    protected Vector3 firstButtonPos = new Vector2 (-100, -150);
    protected Vector3 secondButtonPos = new Vector2(-300, -250);

    protected string machineTag;
    protected Vector3 offset;
    protected GameObject cookingUI;
    protected List<GameObject> listOfMachines;
    private GameObject readyDish = null;

    public float cookingDuration;
    protected virtual void Start()
    {
        ObjectManager.instance.selectedMachine = null;
        firstButtonUI = firstButton.GetComponent<CookingUI>();
        secondButtonUI = secondButton.GetComponent<CookingUI>();
        thirdButtonUI = thirdButton.GetComponent<CookingUI>();
        toEspressoMachineButton = UIManager.instance.goToEspressoMachine;
        toStoveButton = UIManager.instance.goToStove;
    }
    protected virtual void Update()
    {
        GoToCook();
        TryToCook();
    }
    private void GoToCook()
    {
        if (Input.GetMouseButtonDown(0) && !ObjectManager.instance.transformMode && !ObjectManager.instance.isInTheKitchen)
            if (IsMachineSelected(machineTag)) Cook(ObjectManager.instance.selectedMachine, offset, cookingUI);
    }
    private void TryToCook()
    {
        if (ObjectManager.instance.selectedMachine != null)
        {
            if (Input.GetMouseButtonDown(0) && !ObjectManager.instance.selectedMachine.GetComponent<IsBusy>().isBusy)
            {
                if (IsRightMachine(ObjectManager.instance.selectedMachine) && IsValidRecipe())
                {
                    ObjectManager.instance.selectedMachine.GetComponent<IsBusy>().isBusy = true;
                    ReadRecipe();
                }
                else if (IsRightMachine(ObjectManager.instance.selectedMachine) && !IsValidRecipe())
                    DefaultButtons();
            }
        }
    }
    private bool IsRightMachine(GameObject rightMachine)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.gameObject == rightMachine)
                return true;
        }
        return false;
    }
    protected bool IsMachineSelected(string machineTag)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.CompareTag(machineTag))
            {
                ObjectManager.instance.selectedMachine = hit.transform.gameObject;
                return true;
            }
        }
        return false;
    }
    public virtual void Cook(GameObject machine, Vector3 offset, GameObject ingredientButtons)
    {
        Camera.main.transform.position = machine.transform.position + offset;
        ingredientButtons.SetActive(true);
        UIManager.instance.cashRegisterUI.SetActive(true);
        UIManager.instance.shopButton.SetActive(false);
        ObjectManager.instance.isInTheKitchen = true;
        if (ObjectManager.instance.selectedMachine.GetComponent<IsBusy>().isBusy) 
            ObjectManager.instance.selectedMachine.GetComponent<TimerActivator>().cookingTimer.gameObject.SetActive(true);
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
        var machine = ObjectManager.instance.selectedMachine;
        ShowDish(dish, machine);
        StartCooking(machine);
        StartCoroutine(CookingProcess(dish, cookingDuration, machine));
    }
    private IEnumerator CookingProcess(GameObject dish, float cookingDuration, GameObject machine)
    {
        yield return StartCoroutine(Cook(cookingDuration, machine));
        FinishCooking(dish, machine);
    }

    protected virtual void ShowDish(GameObject dish, GameObject machine)
    {
        dish.SetActive(true);
        dish.transform.position = new Vector3(machine.transform.position.x, machine.transform.position.y + 0.6f, machine.transform.position.z - 0.3f);
    }
    protected void StartCooking(GameObject machine)
    {
        var timer = machine.GetComponent<TimerActivator>().cookingTimer;
        timer.GetReady(); 
        timer.gameObject.SetActive(true);
    }

    IEnumerator Cook(float cookingDuration, GameObject machine)
    {
        while (!machine.GetComponent<TimerActivator>().cookingTimer.isLoadFinished)
        {
            machine.GetComponent<TimerActivator>().cookingTimer.StartTheTimer(cookingDuration);
            yield return null;
        }
    }
    protected void FinishCooking(GameObject dish, GameObject machine)
    {
        machine.GetComponent<TimerActivator>().cookingTimer.gameObject.SetActive(false);
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
        readyDish = null;
        dish.SetActive(false);
        machine.GetComponent<IsBusy>().isBusy = false;
        InventoryManager.instance.dishCount++;
    }
    public void OnExitRegimeButtonCkick()
    {
        if (listOfMachines.Count == 0) return;

        if (machineNumber >= listOfMachines.Count)
            machineNumber = 0;

        ObjectManager.instance.selectedMachine = listOfMachines[machineNumber];
        Cook(ObjectManager.instance.selectedMachine, offset, cookingUI);

        machineNumber++;
    }

}







