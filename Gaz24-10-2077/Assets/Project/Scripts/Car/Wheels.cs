using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour
{
    [Header("Wheels")]
    public WheelCollider[] FrontWheels;
    public WheelCollider[] BackWheels;
    [Header("Settings Wheels")]
    public Wheels.Settings _settings;

    [Serializable]
    public class Settings
    {
        public float angleSteeringWheels;
        public float weightOnewheels;
    }
}




