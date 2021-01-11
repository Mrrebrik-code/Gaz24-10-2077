interface IEngine
{
    bool isEnabled { get; set; }
    float Power { get; set; }
    float Weight { get; set; }
    float MotorTorque();
    void StartEngine();
    void StopEngine();

    
}
