using System;
using UnityEngine;

[RequireComponent(typeof(MouseClickRegistering))]

public class CheckingСlickOnCube : MonoBehaviour
{
    public event Action<GameObject> CubeClick;

    private MouseClickRegistering _mouseClickRegistering;

    private void Awake()
    {
        _mouseClickRegistering = GetComponent<MouseClickRegistering>();
    }

    private void OnEnable()
    {
        _mouseClickRegistering.MouseClick += CheckCubeClick;
    }

    private void OnDisable()
    {
        _mouseClickRegistering.MouseClick -= CheckCubeClick;
    }

    private void CheckCubeClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.gameObject.GetComponent<Cube>() != null)
            {
                CubeClick?.Invoke(hit.transform.gameObject);

                break;
            }
        }
    }
}
