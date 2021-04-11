using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Main : MonoBehaviour {

    public MapHandler mapHandlerObject;
    MapHandler mapHandler;

    private void Awake() {
        mapHandler = Instantiate(mapHandlerObject) as MapHandler;
    }

    void Start() {
        NewGame();
        
    }


    void Update() {

    }

    public void NewGame() {
        mapHandler.CreateMap();
    }


}
