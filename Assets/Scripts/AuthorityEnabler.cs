using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class AuthorityEnabler : NetworkBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private GameObject camera;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private ThrowControl throwControlScript;
    [SerializeField] private GameObject CrosshairUI;

    public override void OnStartAuthority()
    {
        controller.enabled = enabled;
        camera.SetActive(true);
        movement.enabled = true;
        throwControlScript.enabled = true;
        CrosshairUI.SetActive(true);
    }
}
