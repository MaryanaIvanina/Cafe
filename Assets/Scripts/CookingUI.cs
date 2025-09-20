using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingUI : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite pressedSprite;

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
            buttonImage.sprite = pressedSprite;
        }
        else
        {
            buttonImage.sprite = defaultSprite;
        }
    }
    public void OnButtonClick()
    {
        isPressed = !isPressed;
    }
}

