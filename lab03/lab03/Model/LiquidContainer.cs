namespace lab03.Model;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool IsHazardous;

    public LiquidContainer(double maxWeight, double selfWeight, double height, double depth, bool isHazardous)
        : base(maxWeight, selfWeight, height, depth, 'L')
    {
        this.IsHazardous = isHazardous;
    }

    public void NotifyDanger(string containerSerialNumber)
    {
        Console.WriteLine($"Dangerous situation detected in container {containerSerialNumber}");
    }

    public override void FillContainer(double weight)
    {
        try
        {
            if (IsHazardous && weight > MaxWeight * 0.5)
            {
                NotifyDanger(SerialNumber);
                throw new InvalidOperationException("Dangerous goods can be filled up to 50% capacity only.");
            }
            else if (!IsHazardous && weight > MaxWeight * 0.9)
            {
                NotifyDanger(SerialNumber);
                throw new InvalidOperationException("Non-dangerous goods can be filled up to 90% capacity only.");
            }
            else
            {
                base.FillContainer(weight);
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}