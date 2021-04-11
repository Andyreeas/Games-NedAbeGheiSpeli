using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour {

    public int q;
    public int r;
    int s;

    public int life = 3;
    Renderer rend;

    public Color color3life;
    public Color color2life;
    public Color color1life;

    private void Awake() {
        rend = GetComponent<Renderer>();
    }

    public void Init(int _r, int _q) {
        q = _q;
        r = _r;
        s = q - r;

        rend.material.color = color3life;
    }


    public void LooseLife() {
        if (life > 1) {
            life -= 1;
            ChangeColor();
        } else {
            Die();
        }
    }

    void ChangeColor() {
        if (life == 2) {
            rend.material.color = color2life;
        } else if (life == 1) {
            rend.material.color = color1life;
        }
    }


    void Die () {
        Debug.Log("Tile deleted.");
        Destroy(gameObject);
    }

}
