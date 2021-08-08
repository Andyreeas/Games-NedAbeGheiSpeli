using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Transports.UNET;

public class NetworkUI : NetworkBehaviour
{

    string serverIp = "127.0.0.1";


    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            serverIp = GUILayout.TextField(serverIp, 25);
            StartButtons(serverIp);
        }
        else
        {
            //StatusLabels();

        }

        GUILayout.EndArea();
    }

    static void StartButtons(string serverIp)
    {
        if (GUILayout.Button("Host")) NetworkManager.Singleton.StartHost();
        if (GUILayout.Button("Server")) NetworkManager.Singleton.StartServer();
        NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = serverIp;
        if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
    }


}
