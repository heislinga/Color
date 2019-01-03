using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ConnectionDiscovery : NetworkDiscovery   
{

    private float timeout = 5f;

    private Dictionary<LanConnnectionInfo, float> lanAddresses = new Dictionary<LanConnnectionInfo, float>();

    public void StartBroadcast(string data)
    {
        broadcastData = data;

        base.Initialize();   
        base.StartAsServer();
    }

    public void StartListening()
    {
        base.Initialize();
        base.StartAsClient();
        StartCoroutine(CleanupExpiredEntries());
    }

    public override void OnReceivedBroadcast(string fromAddress, string data)
    {

        base.OnReceivedBroadcast(fromAddress, data);
        Debug.Log(fromAddress + ", " + data);
        LanConnnectionInfo info = new LanConnnectionInfo(fromAddress, data);

        if (!lanAddresses.ContainsKey(info))
        {
            lanAddresses.Add(info, Time.time + timeout);
            UpdateMatchInfo();
        } else
        {
            lanAddresses[info] = Time.time + timeout;
        }
    }

    private IEnumerator CleanupExpiredEntries()
    {
        while(true)
        {
            bool changed = false;

            var keys = lanAddresses.Keys.ToList();
            foreach(var key in keys)
            {
                if (lanAddresses[key] <= Time.time)
                {
                    lanAddresses.Remove(key);
                    changed = true;
                }
            }

            if (changed)
                UpdateMatchInfo();

            yield return new WaitForSeconds(timeout);
        }
    }

    /// <summary>
    /// Updates the UI list with the available games
    /// </summary>
    private void UpdateMatchInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Found Games: \n");
        foreach(LanConnnectionInfo lan in lanAddresses.Keys.ToList())
        {
            sb.Append(lan.ipAddress + ", Port: " + lan.port + ", Name: " + lan.name);
        }
        Debug.Log(sb.ToString());

        AvailableGamesList.HandleNewGamesList(lanAddresses.Keys.ToList());      
    }


}
