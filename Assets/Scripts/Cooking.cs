using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cooking : MonoBehaviour
{
    protected GameObject selectedMachine;
    protected bool IsMachineSelected(string machineTag)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
            if (hit.transform.CompareTag(machineTag))
            {
                selectedMachine = hit.transform.gameObject;
                return true;
            }
        return false;
    }
    public void Cook(GameObject machine, Vector3 offset, GameObject UI)
    {
        Camera.main.transform.position = machine.transform.position + offset;
        UI.SetActive(true);
        UIManager.instance.cashRegisterUI.SetActive(true);
    }
}
