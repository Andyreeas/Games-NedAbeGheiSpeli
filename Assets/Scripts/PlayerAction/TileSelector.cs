using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    private KeyboardMouseInput keyboardInput;

    //Debug var
    string tileInfo;

    private void Awake()
    {
        keyboardInput = FindObjectOfType<KeyboardMouseInput>();
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
            GameObject currentHex = rayHitInfo.collider.gameObject;
            Destroy(currentHex);
            Debug.Log("Tile to delete: " + currentHex.transform.position);
        }
    }
}
