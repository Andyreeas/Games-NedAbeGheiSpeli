using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFloor : MonoBehaviour
{
    [SerializeField]
    GameObject tilePrefab;
    [SerializeField]
    Transform levelParent;

    [SerializeField]
    int xSize;
    [SerializeField]
    int zSize;

    [SerializeField]
    float tileSize;
    [SerializeField]
    float outlinePercent;

    private void Start()
    {
        for (int x = 0; x < xSize; x++)
        {
            for (int z = 0; z < zSize; z++)
            {
                Vector3 tilePosition = CoordToPosition(x, z);
                //Instantiate tile at position
                GameObject newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right * 90));
                //Set outline for tiles
                newTile.transform.localScale = Vector3.one * (1 - outlinePercent) * tileSize;

                newTile.transform.parent = levelParent;
            }
        }
    }

    Vector3 CoordToPosition(int x, int y)
    {
        return new Vector3(-xSize / 2f + .5f + x, 0, -zSize / 2f + .5f + y) * tileSize;
    }
}
