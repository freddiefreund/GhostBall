using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float mouseSensitivity;
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform childTransform;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float horizontal_axis = Input.GetAxis("Mouse X") * mouseSensitivity;
        float vertical_axis = Input.GetAxis("Mouse Y") * mouseSensitivity;

        playerTransform.eulerAngles = new Vector3(playerTransform.eulerAngles.x, playerTransform.eulerAngles.y + horizontal_axis, 0);
        transform.rotation = playerTransform.rotation;
        childTransform.localEulerAngles = new Vector3(childTransform.localEulerAngles.x - vertical_axis, childTransform.localEulerAngles.y, 0);

        transform.position = transform.position = playerTransform.position;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Cursor.visible = !Cursor.visible;

            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else if (Cursor.lockState == CursorLockMode.None)
                Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

