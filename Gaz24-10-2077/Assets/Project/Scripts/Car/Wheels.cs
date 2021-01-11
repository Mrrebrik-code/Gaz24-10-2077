using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    [Header("Wheels")]
    public WheelCollider[] FrontWheels;
    public WheelCollider[] BackWheels;

    public GameObject[] FrontWheelsMesh;
    public GameObject[] BackWheelsMesh;
    [Header("Settings Wheels")]
    public Wheels.Settings _settings;

    [Serializable]
    public class Settings
    {
        public float angleSteering;
        public float weightOnewheels;
    }
}




