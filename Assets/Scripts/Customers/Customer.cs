using UnityEngine;

public class Customer : MonoBehaviour
{
    private Dish requestedDish; // що хоче клієнт

    void Start()
    {
        requestedDish = OrderManager.instance.GetRandomDish();

        OrderManager.instance.AddOrder(this, requestedDish);
    }

    public void CompleteOrder()
    {
        Destroy(gameObject);
    }

    public Dish GetRequestedDish() => requestedDish;
}
