using System;
using UnityEngine;
using MLAPI;

public class KeyboardMouseInput : NetworkBehaviour
{
    public event Action OnMouseInputLeftDown = delegate { };
    public event Action OnKeyboardInputSpace = delegate { };

    private void Update()
    {
        if (IsLocalPlayer)
        // wichtig, so werden nicht alle instanzen von allen playern aufgerufen
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
}
