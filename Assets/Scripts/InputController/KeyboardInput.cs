using System;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public event Action OnMouseInputLeftDown = delegate { };

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            OnMouseInputLeftDown();
        }
    }
}
