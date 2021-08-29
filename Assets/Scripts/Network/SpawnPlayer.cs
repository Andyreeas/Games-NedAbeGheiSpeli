using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{


    public void RaiseAllPlayers(GameObject localPlayer)
    {
        Vector3 oldPos = localPlayer.transform.position;
        localPlayer.GetComponent<CharacterController>().Move(new Vector3(0, oldPos.y * -1 + 4f, 0));
    }


}


