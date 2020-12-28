interface IEngine
{
    bool isEnabled { get; set; }
    float Power { get; }
    float Weight { get; }
    void Start();
    void Stop();

    
}
