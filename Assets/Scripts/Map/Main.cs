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

    private void Awake()
    {
        mapHandler = Instantiate(mapHandlerObject) as MapHandler;
    }

    void Start()
    {
        Debug.Log("newGame!");
        partieIsRunning = true;
        NewGame();

    }


    void Update()
    {
        // if ((IsServer || IsHost) && !partieIsRunning)
        // {

        // }
    }

    public void NewGame()
    {
        mapHandler.CreateMap();
    }


}
