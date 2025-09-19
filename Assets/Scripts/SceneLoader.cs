using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Slider loadingSlider;

    public float progress = 0;

    void Start()
    {
        loadingSlider.value = 0;
    }
    void Update()
    {
        progress += 0.3f * Time.deltaTime;
        loadingSlider.value = progress;
        if (loadingSlider.value >= 1)
            SceneManager.LoadScene("Gameplay");
    }
}
