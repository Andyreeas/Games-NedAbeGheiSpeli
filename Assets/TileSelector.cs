using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    private KeyboardInput keyboardInput;

    //Debug var
    string tileInfo;

    private void Awake()
    {
        keyboardInput = FindObjectOfType<KeyboardInput>();
    }

    private void OnEnable()
    {
        keyboardInput.OnMouseInputLeftDown += TileSelect;
    }

    private void OnDisable()
    {
        keyboardInput.OnMouseInputLeftDown += TileSelect;
    }

    void TileSelect()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHitInfo;
        
        if (Physics.Raycast(ray, out rayHitInfo))
        {
            GameObject currentHex = rayHitInfo.collider.gameObject;

            Debug.Log("Tile: " + currentHex.transform.position);
        }
    }
}
