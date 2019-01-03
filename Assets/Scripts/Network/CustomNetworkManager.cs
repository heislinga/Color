using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager
{

    public void StartHosting()
    {
        base.StartHost();
    }

    public void StartClient(LanConnnectionInfo info)
    {
        networkAddress = info.ipAddress;
        networkPort = info.port;
        base.StartClient();
    }

    private void OnPlayerConnected(NetworkIdentity id)
    {
        Debug.Log("Player connected!");
    }

}
