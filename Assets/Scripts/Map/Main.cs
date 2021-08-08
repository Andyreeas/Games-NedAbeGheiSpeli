using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using MLAPI;

public class Main : NetworkBehaviour
{

    public MapHandler mapHandlerObject;
    public bool partieIsRunning;
    MapHandler mapHandler;

    public GameObject localPlayerObject;

    private void Awake()
    {
        mapHandler = Instantiate(mapHandlerObject) as MapHandler;

    }

    void Start()
    {
        Debug.Log("newGame!");
        partieIsRunning = false;
        NewGame();

    }


    void Update()
    {
        if ((IsServer || IsHost || IsClient) && !partieIsRunning)
        {
            partieIsRunning = true;
            Debug.Log("NetworkID: " + NetworkManager.Singleton.LocalClientId);
            localPlayerObject = NetworkManager.Singleton.ConnectedClients[NetworkManager.Singleton.LocalClientId].PlayerObject.gameObject;
        }
    }

    public void NewGame()
    {
        mapHandler.CreateMap();
    }


}
