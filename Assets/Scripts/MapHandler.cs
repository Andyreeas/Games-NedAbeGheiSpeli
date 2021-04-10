using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour {

     
    public HexTile hexTile;

    public int mapSize = 9; // muss immer ungerade sein!
    float hexSizeScale = 1;

    int fieldSideSize;

    public HexTile[,] tileArray; //  array für das ganze Feld in  r = row; q = column ( Axial coordinates): tiles[r][q], achtung: x = q, y = r
    public List<HexTile> allTiles;

    private void Awake() {

    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }


    public void CreateMap() {
        // evtl "alte" map löschen zuerst
        Debug.Log("Create Map");

        fieldSideSize = (mapSize - 1) / 2; // die feldgrösse ist halb so gross wie die mapgrösse, da fur eine map im Hex-shape, der ecken links unten, und rechts oben gelöscht werden müssen
        tileArray = new HexTile[mapSize, mapSize]; // erzeugt neues Array mit der grösse

        // fill all spaces of array
        for (int r = 0; r < mapSize; r++) {
            for (int q = 0; q < mapSize; q++) {
                HexTile newHex = Instantiate(hexTile) as HexTile;
                newHex.transform.parent = transform;
                tileArray[r, q] = newHex;
            }
        }

        // subtract for hex-shaped map
        // bottom left removal
        for (int r = 0; r < fieldSideSize; r++) {
            for (int q = fieldSideSize - r - 1; q > -1; q--) {
                Destroy(tileArray[r, q].gameObject);
                tileArray[r, q] = null;
            }
        }
        // top right removal
        for (int r = 0; r < fieldSideSize; r++) {
            for (int q = 0; q < fieldSideSize - r; q++) {
                Destroy(tileArray[mapSize - r - 1, mapSize - q - 1].gameObject);
                tileArray[mapSize - r - 1, mapSize - q - 1] = null;
            }
        }

        // init the rest & create tile list
        allTiles = new List<HexTile>();
        for (int r = 0; r < mapSize; r++) {
            for (int q = 0; q < mapSize; q++) {
                if (tileArray[r, q] != null) {
                    allTiles.Add(tileArray[r, q]);
                    tileArray[r, q].Init(r, q, hexSizeScale);
                }
            }
        }

        // create wall
        // erstes und letztes Objekt in Row wird zur wand, r=0 und r=fieldSideSize komplett auch
        // linke seite
        for (int r = 0; r < mapSize; r++) {
            for (int q = 0; q < mapSize; q++) {
                if (tileArray[r, q] != null) {
                    tileArray[r, q].SetWall();
                    break;
                }
            }
        }
        // rechte seite
        for (int r = 0; r < mapSize; r++) {
            for (int q = mapSize - 1; q > 0; q--) {
                if (tileArray[r, q] != null) {
                    tileArray[r, q].SetWall();
                    break;
                }
            }
        }
        //oben und unten
        for (int q = 0; q < mapSize; q++) {
            if (tileArray[0, q] != null) {
                tileArray[0, q].SetWall();
            }
            if (tileArray[mapSize-1, q] != null) {
                tileArray[mapSize - 1, q].SetWall();
            }
        }
    }

}
