using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    private KeyboardMouseInput keyboardInput;
    private NetworkMap networkMap;

    //Debug var
    string tileInfo;

    private void Awake()
    {
        keyboardInput = GetComponentInChildren<KeyboardMouseInput>();
        networkMap = FindObjectOfType<NetworkMap>();
    }

    private void OnEnable()
    {
        keyboardInput.OnMouseInputLeftDown += TileDelete;
    }

    private void OnDisable()
    {
        keyboardInput.OnMouseInputLeftDown += TileDelete;
    }

    void TileDelete()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHitInfo;

        if (Physics.Raycast(ray, out rayHitInfo))
        {
            HexTile currentHex = rayHitInfo.collider.GetComponent<HexTile>();
            if (!(currentHex.gameObject.layer == LayerMask.NameToLayer("Wall")))
            {
                networkMap.RequestLooseLifeServerRpc(currentHex.r, currentHex.q);
            }
            //Debug.Log("Tile layer: " + LayerMask.LayerToName(currentHex.gameObject.layer));
            //Debug.Log("Tile to delete: " + currentHex.transform.position);
        }
    }
}
