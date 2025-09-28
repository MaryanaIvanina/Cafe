using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingUI : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite selectedSprite;

    private Image buttonImage;
    public bool isPressed = false;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = defaultSprite;
    }
    private void Update()
    {
        if (isPressed)
        {
            buttonImage.sprite = selectedSprite;
        }
        else
        {
            buttonImage.sprite = defaultSprite;
        }
    }
    public void OnButtonPress()
    {
        isPressed = !isPressed;
    }
}
