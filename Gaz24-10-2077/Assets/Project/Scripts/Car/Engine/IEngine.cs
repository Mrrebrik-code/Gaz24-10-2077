interface IEngine
{
    bool isEnabled { get; set; }
    float Power { get; }
    float Weight { get; }
    float MotorTorque();
    void StartEngine();
    void StopEngine();

    
}
