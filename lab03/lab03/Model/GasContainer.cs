namespace lab03.Model;

public class GasContainer : Container, IHazardNotifier
{
    private double pressure;

    public GasContainer(double maxWeight, double selfWeight, double height, double depth, double pressure)
        : base(maxWeight, selfWeight, height, depth, 'G')
    {
        this.pressure = pressure;
    }

    private void CheckPressure()
    {
        if (pressure > 10)
            NotifyDanger(SerialNumber);
    }

    public void NotifyDanger(string containerSerialNumber)
    {
        Console.WriteLine($"Dangerous situation detected in container {containerSerialNumber}");
    }

    public override void EmptyContainer()
    {
        Weight *= 0.05;
    }
}