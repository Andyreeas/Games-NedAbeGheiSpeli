using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using MLAPI;
using MLAPI.Messaging;

public class Main : NetworkBehaviour
{

    public MapHandler mapHandlerObject;
    public bool partieIsRunning;
    MapHandler mapHandler;

    public GameObject localPlayerObject;
    public SpawnPlayer spawnPlayer;

    public event System.Action StartRoundFromLobby;
    public event System.Action EndRound;

    private void Awake()
    {
        mapHandler = Instantiate(mapHandlerObject) as MapHandler;
        spawnPlayer = FindObjectOfType<SpawnPlayer>();
    }

    private void OnEnable()
    {
        StartRoundFromLobby += StartRoundClientRpc;
    }

    private void OnDisable()
    {
        StartRoundFromLobby -= StartRoundClientRpc;
    }

    void Start()
    {
        partieIsRunning = false;
    }


    void Update()
    {
        if ((IsServer || IsHost || IsClient) && !partieIsRunning)
        {
            partieIsRunning = true;
            Debug.Log("NetworkID: " + NetworkManager.Singleton.LocalClientId);
            // localPlayerObject = NetworkManager.Singleton.ConnectedClients[NetworkManager.Singleton.LocalClientId].PlayerObject.gameObject;
            // find in all Players the local Player GameObject
            NetworkPlayerID[] localPlayerObjectList = FindObjectsOfType<NetworkPlayerID>();
            Debug.Log("list: " + localPlayerObjectList[0]);

            foreach (NetworkPlayerID player in localPlayerObjectList)
            {
                print(player.isLocalPlayerID);
                if (player.isLocalPlayerID)
                {
                    localPlayerObject = player.gameObject;
                }
            }
            print(localPlayerObject);
        }
    }

    [ServerRpc]
    public void InitNewRoundServerRpc()
    {
        StartRoundFromLobby?.Invoke();
    }


    [ClientRpc]
    public void StartRoundClientRpc()
    {
        mapHandler.CreateMap();
        spawnPlayer.RaiseAllPlayers(localPlayerObject);
        Cursor.lockState = CursorLockMode.Locked;
    }



}
