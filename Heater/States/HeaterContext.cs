namespace Heater.States;

/// <summary>
/// Contextクラス
/// </summary>
/// <remarks>
/// Clientに公開する窓口を作る
/// </remarks>
public class HeaterContext
{
    //現在の状態を持つ
    private IHeaterState _state = OffState.Instance;
    public event Action? StateChanged;

    public void Up()
    {
        _state.UpState(this);
        Send();
    }

    public void Down()
    {
        _state.DownState(this);
        Send();
    }

    public void OnOff()
    {
        _state.OnOffState(this);
        Send();
    }

    public void Max()
    {
        if (_state is OffState)
        {
            throw new OffException();
        }

        ChangeState(HighState.Instance);
        Send();
    }

    private void Send()
    {
        string path = "heater.txt";
        File.WriteAllLines(path, _state.GetCommand());
    }

    public string GetText()
    {
        return _state.GetText();
    }

    internal void ChangeState(IHeaterState state)
    {
        _state = state;
        StateChanged?.Invoke();
    }
}
