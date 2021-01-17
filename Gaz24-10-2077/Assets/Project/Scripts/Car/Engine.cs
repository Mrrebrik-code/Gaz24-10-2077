using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Engine : MonoBehaviour, IEngine
{
    [SerializeField] private Settings _engineSettings;
    public float Power { get; set; }
    public float Weight { get; set; }
    public bool isEnabled { get; set; }
    void Start()
    {
        Power = _engineSettings.Power;
        Weight = _engineSettings.Weight;
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
        return Power;
    }

    [Serializable]
    public class Settings
    {
        public float Power;
        public float Weight;
    }
}
