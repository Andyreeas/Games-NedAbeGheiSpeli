using System;
using UnityEngine;

public class KeyboardMouseInput : MonoBehaviour
{
    public event Action OnMouseInputLeftDown = delegate { };
    public event Action OnKeyboardInputSpace = delegate { };

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseInputLeftDown();
        }
        if (Input.GetKeyDown("space"))
        {
            OnKeyboardInputSpace();
        }
    }
}
