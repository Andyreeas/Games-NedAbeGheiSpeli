using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour {

    public int q;
    public int r;
    int s;

    public bool isWall = false;
    

    public void Init(int _r, int _q) {
        q = _q;
        r = _r;
        s = q - r;
    }


    public void SetWall() {
        isWall = true;
        transform.localScale = new Vector3(1, 1, 2); // erhöht die wand
    }


    public void LooseLife() {

    }


}
