using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
public class NetworkMap : NetworkBehaviour
{

    MapHandler map;

    private void Awake()
    {
        map = FindObjectOfType<MapHandler>();
    }

    [ServerRpc]
    public void RequestLooseLifeServerRpc(int r, int q)
    {
        Debug.Log("requestLooseLife");
        HexTile currentHex = map.tileArray[r, q];
        if (currentHex.life > 1)
        {
            currentHex.life -= 1;
            ChangeColorClientRpc(r, q, currentHex.life);
        }
        else
        {
            DieClientRpc(r, q);
        }
    }

    [ClientRpc]
    public void ChangeColorClientRpc(int r, int q, int life)
    {
        HexTile currentHex = map.tileArray[r, q];
        if (life == 2)
        {
            currentHex.GetComponent<Renderer>().material.color = currentHex.color2life;
        }
        else if (life == 1)
        {
            currentHex.GetComponent<Renderer>().material.color = currentHex.color1life;
        }
    }


    [ClientRpc]
    public void DieClientRpc(int r, int q)
    {
        HexTile currentHex = map.tileArray[r, q];
        Debug.Log("Tile deleted.");
        Destroy(currentHex.gameObject);
    }


}
