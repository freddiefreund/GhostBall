using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Throw : NetworkBehaviour
{
    [SerializeField] Transform cam = default;
    [SerializeField] GameObject ball = default;
    [SerializeField] float shootPowerMultiplier = 1f;
    [SerializeField] float liveTime = 2f;

    [Command]

    public void CmdThrow(float shootPower)
    {
        var spawnLocation = cam.position + cam.forward * shootPowerMultiplier;   
        var obj = Instantiate(ball, spawnLocation, cam.rotation);
        obj.GetComponent<Rigidbody>().velocity = cam.forward * shootPower * 50;
        NetworkServer.Spawn(obj,connectionToClient);
        
        Destroy(obj.gameObject, liveTime);
    }
}