using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour, IEngine
{
    public float Power { get; }
    public float Weight { get; }
    public bool isEnabled { get; set; }

    public Engine()
    {
        Power = 73.5f;
        Weight = 181f;
        isEnabled = false;
    }
    public void Start()
    {
        isEnabled = true;
    }


    public void Stop()
    {
        isEnabled = false;
    }
}
