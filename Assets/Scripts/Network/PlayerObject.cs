using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        if(!isLocalPlayer)
        {
            // This object belongs to another player
            return;
        } else
        {
            // This object belongs to us
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
