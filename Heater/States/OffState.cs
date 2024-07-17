namespace Heater.States;

public sealed class OffState : IHeaterState
{
    private OffState() { }

    public static OffState Instance { get; } = new OffState();

    public IEnumerable<string> GetCommand()
    {
        return new List<string> { "OFF", "0W" };
    }

    public string GetText()
    {
        return "OFF";
    }

    public void UpState(HeaterContext context)
    {
        throw new OffException();
    }

    public void DownState(HeaterContext context)
    {
        throw new OffException();
    }

    public void OnOffState(HeaterContext context)
    {
        context.ChangeState(LowState.Instance);
    }
}
