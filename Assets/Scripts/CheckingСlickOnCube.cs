using System;
using UnityEngine;

public class CheckingСlickOnCube : MonoBehaviour
{
    private int _idLeftMouseButtom;

    private void Awake()
    {
        _idLeftMouseButtom = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_idLeftMouseButtom))
        {
            CheckCubeClick();
        }
    }

    private void CheckCubeClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.gameObject.GetComponent<CrushingCube>() != null)
            {
                hit.transform.gameObject.GetComponent<CrushingCube>().Crush();

                break;
            }
        }
    }
}
