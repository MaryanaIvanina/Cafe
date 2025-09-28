using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class InventoryItemDisplay : MonoBehaviour
{
    private Image img;

    void Awake()
    {
        img = GetComponent<Image>();

        Button btn = GetComponent<Button>();
        if (btn != null)
            btn.interactable = false;
    }

    public void Initialize(InventoryItemData data)
    {
        img.sprite = data.icon;
    }
}