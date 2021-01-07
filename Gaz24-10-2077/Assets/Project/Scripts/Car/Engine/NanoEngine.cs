using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoEngine : MonoBehaviour, IEngine
{
    public bool isEnabled { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public float Power => throw new System.NotImplementedException();

    public float Weight => throw new System.NotImplementedException();

    public float MotorTorque()
    {
        throw new System.NotImplementedException();
    }

    public void StartEngine()
    {
    }

    public void StopEngine()
    {
        throw new System.NotImplementedException();
    }
}
