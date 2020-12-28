using System;
using System.Collections.Generic;
using UnityEngine;

public enum CarDriveType
{
    FrontWheelDrive,
    BackWheelDrive,
    FullWheelDrive
}
public class CarController : MonoBehaviour
{
    private IEngine engineCar;

    private Engine gaz2410;
    private NanoEngine gaz24102077;

    [Header("Wheels information")]
    [SerializeField] WheelsInfo infoWhiles;

    public  List<WheelsInfo> wheels;

    [SerializeField] float motorTorque;
    [SerializeField] float angleSteeringWhiles;

    private void Awake()
    {
        engineCar = GetComponent<Engine>();
    }

    private void FixedUpdate()
    {

        //if (infoWhiles.typeDrive == CarDriveType.FrontWheelDrive)
        //{
        //    infoWhiles.leftWheel[0].motorTorque = motor;
        //    infoWhiles.rightWheel[0].motorTorque = motor;

        //    infoWhiles.leftWheel[0].steerAngle = angle;
        //    infoWhiles.rightWheel[0].steerAngle = angle;
        //}
    }

    private void Move()
    {

    }

}

[Serializable]
public class WheelsInfo
{
    [Header("Front[0] - Back[1..]")]
    public List<WheelCollider> leftWheel;
    public List<WheelCollider> rightWheel;
    [Space]
    public CarDriveType typeDrive;
}
