using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance;

    public Transform contentParent;         // Content для замовлень
    public GameObject orderPrefab;          // Prefab кнопки замовлення

    public List<Dish> allPossibleDishes;    // Список усіх страв (префаби з Dish.cs)

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void AddOrder(Customer customer, Dish dish)
    {
        GameObject go = Instantiate(orderPrefab, contentParent);
        CustomerOrder order = go.GetComponent<CustomerOrder>();
        order.Initialize(customer, dish);
    }

    public Dish GetRandomDish()
    {
        if (allPossibleDishes.Count == 0) return null;
        return allPossibleDishes[Random.Range(0, allPossibleDishes.Count)];
    }
}
