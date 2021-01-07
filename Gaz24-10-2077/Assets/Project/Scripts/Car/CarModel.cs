using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarModel : MonoBehaviour
{
    [SerializeField] private CarController contoller;
    public Engine _engine;
    public Wheels _wheels; // Колеса

    [SerializeField] private string _name;
    public float _weight;


    public CarDriveType typeDrive;
    public CarMode carMode;

    private Rigidbody rigedbodyCar;
    [SerializeField] private Vector3 centerOfMass;

    private float maxSpeedCar;

    private void Start()
    {
        rigedbodyCar = GetComponent<Rigidbody>();
        rigedbodyCar.centerOfMass = centerOfMass;
    }
    private void FixedUpdate()
    {
        if(carMode == CarMode.Driving)
        {
            contoller.MoveDriving(_wheels.FrontWheels, _wheels.BackWheels, typeDrive);
        }
    }
    private float CalculationWeightCar()
    {
        int currentAmountWheels = _wheels.FrontWheels.Length + _wheels.BackWheels.Length; //Просчет массы передних и задних колес!

        float fullMass = _weight + _engine.Weight + _wheels._settings.weightOnewheels * currentAmountWheels;
        return fullMass;
    }


}
