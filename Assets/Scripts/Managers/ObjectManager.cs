using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [Header("Shop Objects")]
    public GameObject cupBoadCorner;
    public GameObject espressoMachine;
    public GameObject cashRegister;
    public GameObject cupBoardNarrow;
    public GameObject cupBoard01;
    public GameObject cupBoard02;
    public GameObject stove;
    public Dish latte;
    public Dish chocolateCupcake;
    public Dish cherryCupcake;
    public Dish oreoCupcake;
    

    public bool transformMode { get; private set; }
    protected GameObject selectedObject;
    private GameObject newObj;
    private bool IsTouching;

    public static ObjectManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        transformMode = false;
        selectedObject = null;
        newObj = null;
    }
    void Update()
    {
        TransformMode(selectedObject);
        DisableTransform();
    }

    public void PutObject(GameObject obj)
    {
        if (obj != null)
        {
            newObj = Instantiate(obj, obj.transform.position, obj.transform.rotation);
            Purchasable p = newObj.GetComponent<Purchasable>() ?? newObj.AddComponent<Purchasable>();
            newObj.name = p.id;
        }
        EnableTransform(newObj);
    }


    public void TransformMode(GameObject selectedObject)
    {
        float selectedObjectPosition = 0;
        float cursorPosition = 0;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            cursorPosition = hit.point.x;
            selectedObjectPosition = Mathf.Round(cursorPosition * 10) / 20;
        }
        if (transformMode && selectedObject != null)
        selectedObject.transform.position = new Vector3(selectedObjectPosition, selectedObject.transform.position.y, selectedObject.transform.position.z);
    }
    public void DisableTransform()
    {
        if (transformMode)
        {
            IsTouching = selectedObject.GetComponent<TouchingObjects>().isTouching;
            if (IsTouching) return;
            if (Input.GetMouseButtonDown(0))
            {
                if (selectedObject.CompareTag("espressoMachine"))
                {
                    Ray ray = new Ray(selectedObject.transform.position, -transform.up);
                    if (!Physics.Raycast(ray, out RaycastHit hit)) return;
                }
                selectedObject.GetComponent<BoxCollider>().isTrigger = true;
                selectedObject = null;
                newObj = null;
                transformMode = false;
            }
        }
    }

    public void EnableTransform(GameObject obj)
    {
        selectedObject = obj;
        transformMode = true;
        selectedObject.GetComponent<BoxCollider>().isTrigger = false;
    }

}
