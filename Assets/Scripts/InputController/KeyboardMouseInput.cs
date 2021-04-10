using System;
using UnityEngine;

public class KeyboardMouseInput : MonoBehaviour
{
    public event Action OnMouseInputLeftDown = delegate { };

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseInputLeftDown();
        }
    }
}
