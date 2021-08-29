using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;

public class NetworkPlayerID : NetworkBehaviour
{

    public bool isLocalPlayerID = false;

    private void Awake()
    {

        if (IsOwner)
        {
            isLocalPlayerID = true;
        }
    }


}
