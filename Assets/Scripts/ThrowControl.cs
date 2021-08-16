using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class ThrowControl : MonoBehaviour
{
    [SerializeField] float maxChargeTime = 1.5f;
    [SerializeField] private Image crosshair;

    float timeStamp = 0;
    private const float defaultCrosshairAlpha = 0.1f;
    private bool clicking = false;
    private float shootPower;
    private Throw throwScript;

    private void Start()
    {
        throwScript = GetComponent<Throw>();
        setCrosshairAlpha();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            timeStamp = Time.time;
            clicking = true;
        }
        
        if (clicking)
        {
            shootPower = Time.time - timeStamp;
            shootPower = Mathf.Clamp(shootPower, 0.1f, maxChargeTime) * 1.5f;
            setCrosshairAlpha(shootPower / 3);
        }

        if (Input.GetMouseButtonUp(0))
        {
            clicking = false;
            throwScript.CmdThrow(shootPower);
            setCrosshairAlpha();
        }
    }

    void setCrosshairAlpha(float alpha = 0f)
    {
        Color c = crosshair.color;
        c.a = alpha + defaultCrosshairAlpha;
        crosshair.color = c;
    }
}
