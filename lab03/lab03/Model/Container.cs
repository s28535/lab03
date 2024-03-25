namespace lab03.Model;

public abstract class Container
{
    protected double MaxWeight { get; }
    protected double SelfWeight { get; }
    protected double Height { get; }
    protected double Depth { get; }
    protected string SerialNumber { get; }
    private static int ID = 0;
    protected double Weight { get; set; }

    protected Container(double maxWeight, double selfWeight, double height, double depth, char serialLetter)
    {
        MaxWeight = maxWeight;
        SelfWeight = selfWeight;
        Height = height;
        Depth = depth;
        SerialNumber = $"KON-{serialLetter}-{ID++}";
    }

    public virtual void EmptyContainer()
    {
        Weight = 0;
    }

    public virtual void FillContainer(double weight)
    {
        try
        {
            if (weight > MaxWeight)
                throw new OverfillException();
            else
                Weight = weight;
        }
        catch (OverfillException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}