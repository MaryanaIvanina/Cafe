using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager instance;

    public Transform contentParent;         
    public GameObject orderPrefab;

    public List<Dish> allPossibleDishes;    

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
