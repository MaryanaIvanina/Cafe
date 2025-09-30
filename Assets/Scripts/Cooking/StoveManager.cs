using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoveManager : Cooking
{
    [Header("Cupscakes")]
    public GameObject chocolateCupcake;
    public GameObject cherryCupcake;
    public GameObject oreoCupcake;

    public GameObject fourthButton;
    public CookingUI fourthButtonUI;

    protected override void Start()
    {
        base.Start();
        fourthButtonUI = fourthButton.GetComponent<CookingUI>();
        machineTag = "stove";
        offset = new Vector3(-0.5f, 0.8f, -2.3f);
        cookingUI = UIManager.instance.cupcakes;
        listOfMachines = ObjectManager.instance.stoves;
    }

    override protected void ReadRecipe()
    {
        if (firstButtonUI.isPressed && secondButtonUI.isPressed && !thirdButtonUI.isPressed && !fourthButtonUI.isPressed) CookDish(chocolateCupcake, 0.3f);
        else if (firstButtonUI.isPressed && !secondButtonUI.isPressed && thirdButtonUI.isPressed && !fourthButtonUI.isPressed) CookDish(cherryCupcake, 0.1f);
        else if (firstButtonUI.isPressed && !secondButtonUI.isPressed && !thirdButtonUI.isPressed && fourthButtonUI.isPressed) CookDish(oreoCupcake, 0.05f);

        DefaultButtons();
    }
    override protected bool IsValidRecipe()
    {
        if (firstButtonUI.isPressed && secondButtonUI.isPressed && !thirdButtonUI.isPressed && !fourthButtonUI.isPressed)
            return true;
        else if (firstButtonUI.isPressed && !secondButtonUI.isPressed && thirdButtonUI.isPressed && !fourthButtonUI.isPressed)
            return true;
        else if (firstButtonUI.isPressed && !secondButtonUI.isPressed && !thirdButtonUI.isPressed && fourthButtonUI.isPressed)
            return true;
        return false;
    }
    override protected void DefaultButtons()
    {
        base.DefaultButtons();
        fourthButtonUI.isPressed = false;
    }
    override protected void ShowDish(GameObject dish, GameObject machine)
    {
        base.ShowDish(dish, machine);
        dish.transform.position = new Vector3(machine.transform.position.x,
            machine.transform.position.y + 0.6f,
            machine.transform.position.z - 0.3f);
    }
    public override void Cook(GameObject machine, Vector3 offset, GameObject ingredientButtons)
    {
        base.Cook(machine, offset, ingredientButtons);
        toEspressoMachineButton.SetActive(true);
        toEspressoMachineButton.GetComponent<RectTransform>().anchoredPosition = firstButtonPos;
        if (listOfMachines.Count > 1)
        {
            toStoveButton.SetActive(true);
            toStoveButton.GetComponent<RectTransform>().anchoredPosition = secondButtonPos;
        }
    }
}