using Heater.Context;

namespace Heater.States;

/// <summary>
/// 中状態
/// </summary>
public sealed class MiddleState : IHeaterState
{
    private MiddleState() { }

    public static MiddleState Instance { get; } = new MiddleState();

    public IEnumerable<string> GetCommand()
    {
        return new List<string> { "Mid", "700W" };
    }

    public string GetText()
    {
        return "Mid";
    }

    public void UpState(HeaterContext context)
    {
        context.ChangeState(HighState.Instance);
    }

    public void DownState(HeaterContext context)
    {
        context.ChangeState(LowState.Instance);
    }

    public void OnOffState(HeaterContext context)
    {
        context.ChangeState(OffState.Instance);
    }
}
