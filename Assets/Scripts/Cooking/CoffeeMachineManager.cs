
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeMachineManager : Cooking
{
    [Header("Cups")]
    public GameObject espressoCup;
    public GameObject americanoCup;
    public GameObject latteCup;

    protected override void Start()
    {
        base.Start();
        machineTag = "espressoMachine";
        offset = new Vector3(-0.5f, 0.3f, -1.5f);
        cookingUI = UIManager.instance.coffee;
    }

    override protected void ReadRecipe()
    {
        if (!secondButtonUI.isPressed && !thirdButtonUI.isPressed) CookDish(espressoCup, 0.9f);
        else if (secondButtonUI.isPressed && !thirdButtonUI.isPressed) CookDish(americanoCup, 0.5f);
        else if (secondButtonUI.isPressed && thirdButtonUI.isPressed) CookDish(latteCup, 0.3f);

        DefaultButtons();
    }
    override protected bool IsValidRecipe()
    {
        if (firstButtonUI.isPressed && !secondButtonUI.isPressed && !thirdButtonUI.isPressed) return true;
        else if (firstButtonUI.isPressed && secondButtonUI.isPressed && !thirdButtonUI.isPressed) return true;
        else if (firstButtonUI.isPressed && secondButtonUI.isPressed && thirdButtonUI.isPressed) return true;
        return false;
    }
    override protected void ShowDish(GameObject dish)
    {
        base.ShowDish(dish);
        dish.transform.position = selectedMachine.transform.position;
    }
}

