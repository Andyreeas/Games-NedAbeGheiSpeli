using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CrossFeed : MonoBehaviour
{

    // KeyboardMouseInput keyboardMouseInput;

    // GameObject player;

    public Texture CFOpen;
    public Texture CFClosed;

    RawImage rawImg;
    private void Awake()
    {
        rawImg = gameObject.GetComponent<RawImage>();
        // player = FindObjectOfType<Main>().localPlayerObject; // REDO, zimmlich scheisse so...
        // keyboardMouseInput = player.GetComponentInChildren<KeyboardMouseInput>();
    }

    // private void OnEnable()
    // {
    //     keyboardMouseInput.OnMouseInputLeftDown += fired;
    // }

    // private void OnDisable()
    // {
    //     keyboardMouseInput.OnMouseInputLeftDown -= fired;
    // }


    public IEnumerator Fired()
    {
        rawImg.texture = CFClosed;
        yield return new WaitForSeconds(0.1f);
        rawImg.texture = CFOpen;
    }



}
