using System;
using UnityEngine;

public class MouseClickRegistering : MonoBehaviour
{
    public event Action MouseClick;

    private int _idLeftMouseButtom;

    private void Awake()
    {
        _idLeftMouseButtom = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_idLeftMouseButtom))
        {
            MouseClick?.Invoke();
        }
    }
}
