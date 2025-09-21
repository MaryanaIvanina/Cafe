using UnityEngine;

public class Customer : MonoBehaviour
{
    private Dish requestedDish; // що хоче клієнт

    void Start()
    {
        // Випадкове замовлення зі списку (для простоти можна хардкодом)
        requestedDish = OrderManager.instance.GetRandomDish();

        // Показати замовлення в UI
        OrderManager.instance.AddOrder(this, requestedDish);
    }

    // Викликається, коли гравець виконав замовлення
    public void CompleteOrder()
    {
        Destroy(gameObject); // клієнт іде
    }

    public Dish GetRequestedDish() => requestedDish;
}
