using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MovementEnabler : NetworkBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] PlayerMovement movement;

    public override void OnStartAuthority()
    {
        movement.enabled = true;
        controller.enabled = true;
    }
}
