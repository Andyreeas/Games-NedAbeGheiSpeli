using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrder : MonoBehaviour {

    public Player playerEmpty;
    public Player playerOne;
    public Player playerTwo;

    public Player activePlayer;

    public event System.Action EventPlayerChange;

    private void Awake() {
        playerEmpty = new Player("Empty", Color.white);
        playerOne = new Player("Player 1", Color.blue);
        playerTwo = new Player("Player 2", Color.red);
        
    }


    void Start() {
        SetStartPlayer();
    }


    void Update() {

    }


    void SetStartPlayer() {
        if (Random.value > 0.5f) { // rand bool
            activePlayer = playerOne;
        } else {
            activePlayer = playerOne;
        }
        EventPlayerChange?.Invoke();
    }

    public void Next() {
        activePlayer = (activePlayer == playerOne) ? playerTwo : playerOne;
        EventPlayerChange?.Invoke();
    }

    public struct Player {
        public string name;
        public Color color;

        public Player (string _name, Color _color) {
            name = _name;
            color = _color;
        }

        public static bool operator ==(Player p1, Player p2) {
            return p1.name == p2.name;
        }
        public static bool operator !=(Player p1, Player p2) {
            return !(p1.name == p2.name);
        }
    }



}
