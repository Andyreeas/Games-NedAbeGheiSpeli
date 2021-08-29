using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using UnityEngine.UI;
using MLAPI.Transports.UNET;


public class UILobby : NetworkBehaviour
{
    public Main main;
    public GameObject uIMenu;
    public GameObject startButton;


    private void Awake()
    {
        main = FindObjectOfType<Main>();
    }

    private void OnEnable()
    {
        main.StartRoundFromLobby += Deactivate;
    }

    private void OnDisable()
    {
        main.StartRoundFromLobby -= Deactivate;
    }


    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        if (IsClient && !IsHost)
        {
            startButton.SetActive(false);
        }
    }

    public void BtnStart()
    {
        main.InitNewRoundServerRpc();
        Deactivate();
    }

    public void Exit()
    {
        uIMenu.SetActive(true);
        Deactivate();
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
