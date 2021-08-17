using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    float maxTileRange = 10f;

    private KeyboardMouseInput keyboardInput;
    private NetworkMap networkMap;
    CrossFeed CF;

    //Debug var
    string tileInfo;

    private void Awake()
    {
        keyboardInput = GetComponentInChildren<KeyboardMouseInput>();
        networkMap = FindObjectOfType<NetworkMap>();
        CF = FindObjectOfType<CrossFeed>();
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
        StartCoroutine(CF.Fired());
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHitInfo;
        
        //Max length set to maxTileRange float
        if (Physics.Raycast(ray, out rayHitInfo, maxTileRange))
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
