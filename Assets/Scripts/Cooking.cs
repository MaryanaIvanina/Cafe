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
        Camera.main.transform.position = new Vector3 (machine.transform.position.x + offset.x, machine.transform.position.y + offset.y, machine.transform.position.z + offset.z);
        UI.SetActive(true);
        UIManager.instance.cashRegisterUI.SetActive(true);
    }
}
