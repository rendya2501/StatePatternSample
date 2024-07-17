namespace Heater.States;

public sealed class LowState : IHeaterState
{
    private LowState() { }

    public static LowState Instance { get; } = new LowState();

    public IEnumerable<string> GetCommand()
    {
        return new List<string> { "Low", "500W" };
    }

    public string GetText()
    {
        return "Lo";
    }

    public void UpState(HeaterContext context)
    {
        context.ChangeState(MiddleState.Instance);
    }

    public void DownState(HeaterContext context)
    {
        context.ChangeState(HighState.Instance);
    }

    public void OnOffState(HeaterContext context)
    {
        context.ChangeState(OffState.Instance);
    }
}
