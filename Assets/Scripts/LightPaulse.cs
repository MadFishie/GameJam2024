using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPaulse : MonoBehaviour
{
    private bool Waxing = true;
    private float LightIntesity;
    [SerializeField] private float MinIntesity;
    [SerializeField] private float MaxIntesity;
    [SerializeField] private float PaulseSpeed;

    private void Start()
    {      
        PaulseSpeed = PaulseSpeed / 60;
    }
    void FixedUpdate()
    {
        if(Waxing == true)
        {
            LightIntesity += PaulseSpeed;
            this.GetComponent<Light2D>().intensity = LightIntesity;
            if (LightIntesity >= MaxIntesity)
            {
                Waxing = false;
            }
        }
        else
        {
            LightIntesity -= PaulseSpeed;
            this.GetComponent<Light2D>().intensity = LightIntesity;
            if (LightIntesity <= MinIntesity)
            {
                Waxing = true;
            }
        }
    }
}
