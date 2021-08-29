using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class CameraSwitch : NetworkBehaviour
{


    public GameObject cameraPlayer;

    GameObject cameraLobby;
    Main main;

    UILobby uILobby;


    private void Awake()
    {
        cameraLobby = GameObject.Find("CamLobby");
        main = FindObjectOfType<Main>();
    }

    private void OnEnable()
    {
        if (IsOwner)
        {
            main.StartRoundFromLobby += SwitchToPlayer;
            main.EndRound += SwitchToLobby;
            GetComponent<DeathDetection>().PlayerDeath += SwitchToLobby;
        }
    }

    private void OnDisable()
    {
        if (IsOwner)
        {
            main.StartRoundFromLobby -= SwitchToPlayer;
            main.EndRound -= SwitchToLobby;
            GetComponent<DeathDetection>().PlayerDeath -= SwitchToLobby;
        }
    }


    private void Start()
    {

    }

    void SwitchToPlayer()
    {
        Debug.Log("switch to PlayerCam");
        cameraPlayer.gameObject.SetActive(true);
        cameraLobby.SetActive(false);
    }

    void SwitchToLobby()
    {
        Debug.Log("switch to LobbyCam");
        cameraPlayer.gameObject.SetActive(false);
        cameraLobby.SetActive(true);
    }

}
