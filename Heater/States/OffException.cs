namespace Heater.States;

internal sealed class OffException : Exception
{
    public OffException() : base("まずはONにしてください。") { }
}
