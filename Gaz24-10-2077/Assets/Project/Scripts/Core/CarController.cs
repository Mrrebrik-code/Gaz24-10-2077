using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CarController : MonoBehaviour
{
    public InputState _inputState; //Состояние ввода пользователя
    [SerializeField] private Wheels _wheels; // Колеса

    public Engine _engineCar; //Двигатель

    [SerializeField] private float brakeForce;
    [SerializeField] private float accel;

    [SerializeField] private Vector3 m_CentreOfMassOffset; // Смещение центра массы автомобиля


    public void MoveDriving(WheelCollider[] _FrontWheels, WheelCollider[] _BackWheels, CarDriveType typeDrive)
    {
        if(typeDrive == CarDriveType.FrontWheelDrive)
        {
            Move(_FrontWheels);
        }
        if(typeDrive == CarDriveType.BackWheelDrive)
        {
            Move(_BackWheels);
        }
        if (typeDrive == CarDriveType.FullWheelDrive)
        {
            Move(_FrontWheels, _BackWheels);
        }

        HandeBrake(_FrontWheels, _BackWheels);

        if (_inputState.isInputState == false)
        {
            foreach (WheelCollider wheels in _FrontWheels)
            {
                wheels.motorTorque = 0;
            }
            foreach (WheelCollider wheels in _BackWheels)
            {
                wheels.motorTorque = 0;
            }
        }


    }

    private void Move(WheelCollider[] _Wheels)
    {
        if (_inputState.isUpMove)
        {
            foreach (WheelCollider wheels in _Wheels)
            {
                wheels.motorTorque = _engineCar.MotorTorque() * accel;
            }
        }
        if (_inputState.isDownMove)
        {
            foreach (WheelCollider wheels in _Wheels)
            {
                wheels.motorTorque = -(_engineCar.MotorTorque()) * accel;
            }
        }
    }
    private void Move(WheelCollider[] _FrontWheels, WheelCollider[] _BackWheels)
    {
        if (_inputState.isUpMove)
        {
            foreach (WheelCollider wheels in _FrontWheels)
            {
                wheels.motorTorque = _engineCar.MotorTorque() * 1;
            }
            foreach (WheelCollider wheels in _BackWheels)
            {
                wheels.motorTorque = _engineCar.MotorTorque() * 1;
            }
        }
        if (_inputState.isDownMove)
        {
            foreach (WheelCollider wheels in _FrontWheels)
            {
                wheels.motorTorque = -(_engineCar.MotorTorque()) * 1;
            }
            foreach (WheelCollider wheels in _BackWheels)
            {
                wheels.motorTorque = -(_engineCar.MotorTorque()) * 1;
            }
        }
    }
    private void HandeBrake(WheelCollider[] _FrontWheels, WheelCollider[] _BackWheels)
    {
        if (_inputState.isHandBrake)
        {
            foreach (WheelCollider wheels in _FrontWheels)
            {
                wheels.brakeTorque += brakeForce;
            }
            foreach (WheelCollider wheels in _BackWheels)
            {
                wheels.brakeTorque += brakeForce;
            }
        }
        else
        {
            foreach (WheelCollider wheels in _FrontWheels)
            {
                wheels.brakeTorque = 0;
            }
            foreach (WheelCollider wheels in _BackWheels)
            {
                wheels.brakeTorque = 0;
            }
        }
    }
}
