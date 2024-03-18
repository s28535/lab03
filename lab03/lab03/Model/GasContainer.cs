namespace lab03.Model;

public class GasContainer : Container, IHazardNotifier
{
    private double pressure;

    public GasContainer(double maxWeight, double selfWeight, double height, double depth, double pressure)
        : base(maxWeight, selfWeight, height, depth, 'G')
    {
        this.pressure = pressure;
    }

    public void NotifyDanger(string containerSerialNumber)
    {
        Console.WriteLine($"Dangerous situation detected in container {containerSerialNumber}");
    }

    public override void EmptyContainer()
    {
        try
        {
            if (Weight > MaxWeight)
            {
                NotifyDanger(SerialNumber);
                throw new InvalidOperationException("Overfilled container detected.");
            }
            else
            {
                Weight *= 0.95; // Leave 5% of the gas inside the container
                base.EmptyContainer();
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}