using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class CustomerOrder : MonoBehaviour
{
    private Customer customer;
    private Dish dish;
    private Button btn;
    private Image img;

    public void Initialize(Customer c, Dish d)
    {
        customer = c;
        dish = d;
        btn = GetComponent<Button>();
        img = GetComponent<Image>();
        img.sprite = dish.orderIcon;
        btn.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // ЄДИНЕ МІСЦЕ, де відбувається вся логіка!
        bool hasRequiredItem = InventoryManager.instance.TryFulfillOrder(dish.sellPrice);

        if (hasRequiredItem)
        {
            // Додаємо гроші (тільки тут!)
            MoneyManager.Instance.AddMoney(dish.sellPrice);

            // Завершуємо замовлення
            customer.CompleteOrder();
            Destroy(gameObject);

            Debug.Log($"Замовлення виконано! Отримано {dish.sellPrice} грошей.");
        }
        else
        {
            Debug.Log("У інвентарі немає потрібної страви!");

            // Опціонально: можна додати візуальний ефект помилки
            // Наприклад, трясти кнопку або змінити колір
        }
    }

    void OnDestroy()
    {
        if (btn != null)
            btn.onClick.RemoveListener(OnClick);
    }
}