using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingTimer : MonoBehaviour
{
    [SerializeField] private Slider cookingTime;
    private float progress;
    public bool isLoadFinished { get; private set; }
    public void GetReady()
    {
        progress = 0f;
        cookingTime.value = 0;
        isLoadFinished = false;
    }
    public void StartTheTimer(float duration)
    {
        progress += duration * Time.deltaTime;
        cookingTime.value = progress;
        if (cookingTime.value >= 1)
            isLoadFinished = true;
    }
}
