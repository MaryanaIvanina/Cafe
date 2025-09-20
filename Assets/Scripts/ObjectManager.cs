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

    public bool transformMode { get; private set; }
    protected GameObject selectedObject;
    private GameObject newObj;

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
        Vector3 position;
        Quaternion rotation;

        if (obj != espressoMachine && obj != cashRegister)
        {
            position = new Vector3(0, -1.4f, 0);
            rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (obj == cashRegister)
        {
            position = new Vector3(0, 0, -3.7f);
            rotation = Quaternion.Euler(-90, 0, 90);
        }
        else
        {
            position = new Vector3(0, 0, 0);
            rotation = Quaternion.Euler(0, 180, 0);
        }

        if (obj != null)
            newObj = Instantiate(obj, position, rotation);
        EnableTransform(newObj);
    }

    public void TransformMode(GameObject selectedObject)
    {
        if (transformMode && selectedObject != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
                selectedObject.transform.position = new Vector3(hit.point.x, selectedObject.transform.position.y, selectedObject.transform.position.z);
        }
    }
    public void DisableTransform()
    {
        if (Input.GetMouseButtonDown(0) && transformMode)
        {
            selectedObject = null;
            newObj = null;
            transformMode = false;
        }
    }

    public void EnableTransform(GameObject obj)
    {
        selectedObject = obj;
        transformMode = true;
    }
}
