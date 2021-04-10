using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour {

    public int q;
    public int r;
    int s;

    public bool isWall = false;
    float width;
    float height;

    Vector3 posVector;
    


    private void Awake() {
        //spriteRenderPrev = spritePosPreview.GetComponent<SpriteRenderer>();
        //spriteRenderPrev.sprite = null;
        //spriteRenderAct = spritePosActive.GetComponent<SpriteRenderer>();
        //spriteRenderAct.sprite = spritesActive[0];

    }

    void Start()
    {


    }

    void Update()
    {


    }




    public void Init(int _r, int _q, float sizeScale) {
        q = _q;
        r = _r;
        s = q - r;

        width = Mathf.Sqrt(3) * sizeScale;
        height = 2 * sizeScale;
        transform.localScale = new Vector3(sizeScale*0.95f, sizeScale * 0.95f, 1); // für etwas rand 95%
         
        SetCenter();
    }


    void SetCenter() {
        posVector.x = (r * width / 2) + (q * width);
        posVector.y = 0;
        posVector.z = r * (height * 3 / 4);
        transform.position = posVector;
        transform.Rotate(-90.0f, 0.0f, 0.0f,Space.World);
    }


    public void SetWall() {
        isWall = true;
        transform.localScale = new Vector3(1, 1, 2); // erhöht die wand
    }

}
