using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDetection : MonoBehaviour
{

    GameObject deathPlane;
    Main main;
    bool canDetect;

    public event System.Action PlayerDeath;


    private void Awake()
    {
        deathPlane = GameObject.Find("PlaneDeath");
        main = FindObjectOfType<Main>();
    }

    private void OnEnable()
    {
        main.StartRoundFromLobby += enableDetection;
    }

    private void OnDisable()
    {
        main.StartRoundFromLobby -= enableDetection;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (canDetect && (other.gameObject == deathPlane))
        {
            // Wenn Collider deathPlane ist, Invoke
            Debug.Log("player Died");
            PlayerDeath?.Invoke();
        }
    }

    void enableDetection()
    {
        canDetect = true;
    }

}
