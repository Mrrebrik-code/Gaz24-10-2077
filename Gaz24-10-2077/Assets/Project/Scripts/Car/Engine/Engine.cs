using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Engine : MonoBehaviour, IEngine
{
    private Settings _engineSettings;
    public float Power { get; }
    public float Weight { get; }
    public bool isEnabled { get; set; }

    public Engine()
    {
        Power = 74;
        Weight = 181;
        isEnabled = false;
    }
    public void StartEngine()
    {
        isEnabled = true;
    }


    public void StopEngine()
    {
        isEnabled = false;
    }

    public float MotorTorque()
    {
        //Простенькое - заменить
        return 10000000000f;
    }

    [Serializable]
    public class Settings
    {
        public float Power;
        public float Weight;
    }
}
