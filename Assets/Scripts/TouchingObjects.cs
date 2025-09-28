using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingObjects : MonoBehaviour
{
    public bool isTouching = false;
    public void OnTriggerEnter(Collider other)
    {
        isTouching = true;
    }
    public void OnTriggerExit(Collider other)
    {
        isTouching = false;
    }
}
