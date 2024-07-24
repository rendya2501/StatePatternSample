using Heater.Context;
using Heater.Exceptions;

namespace Heater.States;

/// <summary>
/// Off状態
/// </summary>
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
        // offの状態でUpボタンを押下したら警告する
        throw new OffException();
    }

    public void DownState(HeaterContext context)
    {
        // offの状態でDownボタンを押下したら警告する
        throw new OffException();
    }

    public void OnOffState(HeaterContext context)
    {
        // Offの状態からOn/Offボタンを押下したらLowからスタートする
        context.ChangeState(LowState.Instance);
    }
}
