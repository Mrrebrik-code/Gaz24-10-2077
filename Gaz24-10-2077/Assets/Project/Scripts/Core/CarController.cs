using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CarController : MonoBehaviour
{
    public InputState _inputState; //Состояние ввода пользователя
    [SerializeField] private Wheels _wheels; // Колеса

    public Engine _engineCar; //Двигатель
    private Rigidbody rigidbodyCar;

    [SerializeField] private float brakeForce;
    [SerializeField] private float accel;
    bool isStoping;
    public bool isMoving;
    [SerializeField] private float timeStoping = 2f;
    private float currentTimeStoping;

    [SerializeField] private float maxSpeed;

    private void Awake()
    {
        currentTimeStoping = timeStoping;
        rigidbodyCar = GetComponent<Rigidbody>();
    }
    private void WheelMeshing()
    {
        
        Quaternion rotationFront, rotationBack;
        Vector3 positionFront, positionBack;
        for (int i = 0; i < _wheels.FrontWheelsMesh.Length; i++)
        {
            _wheels.FrontWheels[i].GetWorldPose(out positionFront, out rotationFront);
            _wheels.FrontWheelsMesh[i].transform.position = positionFront;
            _wheels.FrontWheelsMesh[i].transform.rotation = Quaternion.Euler(rotationFront.eulerAngles.x, rotationFront.eulerAngles.y, rotationFront.eulerAngles.z - 90);

            _wheels.BackWheels[i].GetWorldPose(out positionBack,out rotationBack);
            _wheels.BackWheelsMesh[i].transform.position = positionBack;
            _wheels.BackWheelsMesh[i].transform.localRotation = Quaternion.Euler(rotationBack.x, rotationBack.y, rotationBack.z - 90);
        }
    }
    public void MoveDriving(WheelCollider[] _FrontWheels, WheelCollider[] _BackWheels, CarDriveType typeDrive)
    {

        WheelMeshing();
        if (_inputState.isHandBrake || isStoping)
            HandeBrake(_FrontWheels, _BackWheels);
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
        Rotation(_FrontWheels);
        StopingCar(_FrontWheels, _BackWheels);
        if (!isMoving)
        {

            isStoping = false;

        }
        if (typeDrive == CarDriveType.FrontWheelDrive)
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
    }
    private void StopingCar(WheelCollider[] _FrontWheels, WheelCollider[] _BackWheels)
    {
        if (_inputState.isDownMove == false && _inputState.isUpMove == false && isMoving)
        {
            currentTimeStoping -= Time.deltaTime;
            if (currentTimeStoping <= 0)
            {
                Debug.Log("Останавка");
                isStoping = true;
                currentTimeStoping = timeStoping;
            }
        }

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
    private void FlipCar(WheelCollider[] _FrontWheels)
    {
       if(Mathf.Round( rigidbodyCar.velocity.magnitude) > maxSpeed && _FrontWheels[0].steerAngle >= _wheels._settings.angleSteering)
        {
            rigidbodyCar.centerOfMass = Vector3.zero;
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
    private void Rotation(WheelCollider[] _Wheels)
    {
        if (_inputState.isLeftMove)
        {
            foreach (WheelCollider wheels in _Wheels)
            {
                wheels.steerAngle = -(_wheels._settings.angleSteering);
            }
        }
        if (_inputState.isRightMove)
        {
            foreach (WheelCollider wheels in _Wheels)
            {
                wheels.steerAngle = _wheels._settings.angleSteering;
            }
        }
        if (_inputState.isRightMove == false && _inputState.isLeftMove == false)
        {
            foreach (WheelCollider wheels in _Wheels)
            {
                wheels.steerAngle = 0;
            }
        }
    }
    private void HandeBrake(WheelCollider[] _FrontWheels, WheelCollider[] _BackWheels)
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
}
