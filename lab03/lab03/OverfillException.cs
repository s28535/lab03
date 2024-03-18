using System.Transactions;

namespace lab03;

public class OverfillException : Exception
{
    public OverfillException() : base("Too much weight!")
    {
    }
}