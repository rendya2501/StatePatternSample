namespace Heater.Exceptions;

internal sealed class OffException : Exception
{
    public OffException() : base("まずはONにしてください。") { }
}
