using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;

public class HexTile : MonoBehaviour
{

    public int q;
    public int r;

    private float hexSize;

    public int life = 3;
    Renderer rend;

    public Color color3life;
    public Color color2life;
    public Color color1life;

    private void Awake()
    {
        //comment 
        rend = GetComponent<Renderer>();
    }

    public void Init(int _r, int _q, float _hexSize)
    {
        q = _q;
        r = _r;
        hexSize = _hexSize;
        SetTilePosition();

        rend.material.color = color3life;
    }


    void SetTilePosition()
    {
        float width = Mathf.Sqrt(3) * hexSize;
        float height = 2 * hexSize;
        transform.localScale = new Vector3(hexSize * 0.95f, hexSize * 0.95f, 1); // für etwas rand 95%

        Vector3 posVector = new Vector3();
        posVector.x = (r * width / 2) + (q * width);
        posVector.y = 0;
        posVector.z = r * (height * 3 / 4);
        transform.position = posVector;
        transform.Rotate(-90.0f, 0.0f, 0.0f, Space.World);
    }

    // public void LooseLife()
    // {
    //     if (life > 1)
    //     {
    //         life -= 1;
    //         ChangeColor();
    //     }
    //     else
    //     {
    //         Die();
    //     }
    // }

}
