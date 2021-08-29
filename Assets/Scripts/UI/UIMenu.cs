using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAPI;
using MLAPI.Transports.UNET;
using TMPro;


public class UIMenu : NetworkBehaviour
{
    public Main main;
    public GameObject uILobby;
    public GameObject iPInputField;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        uILobby.SetActive(true);
        gameObject.SetActive(false);
    }
    public void JoinLobby()
    {
        try
        {
            NetworkManager.Singleton.StopClient();
        }
        catch
        {
            Debug.Log("no Client to Destroy");
        }

        NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = iPInputField.GetComponent<TMP_InputField>().text;
        try
        {
            NetworkManager.Singleton.StartClient();
        }
        catch
        {
            Debug.Log("Cant connect to IP");
            return;
        }
        bool connection = NetworkManager.Singleton.IsConnectedClient;
        Debug.Log(IsClient + " " + connection);
        uILobby.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
