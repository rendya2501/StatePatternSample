namespace Heater.States;

public sealed class HighState : IHeaterState
{
    private HighState() { }

    public static HighState Instance { get; } = new HighState();

    public IEnumerable<string> GetCommand()
    {
        return new List<string> { "Hi", "1000W" };
    }

    public string GetText()
    {
        return "Hi";
    }

    public void UpState(HeaterContext context)
    {
        context.ChangeState(LowState.Instance);
    }

    public void DownState(HeaterContext context)
    {
        context.ChangeState(MiddleState.Instance);
    }

    public void OnOffState(HeaterContext context)
    {
        context.ChangeState(OffState.Instance);
    }
}
