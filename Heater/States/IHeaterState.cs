namespace Heater.States;

//状態を同一視するためのインタフェース
public interface IHeaterState
{
    void UpState(HeaterContext context);
    void DownState(HeaterContext context);
    void OnOffState(HeaterContext context);
    string GetText();
    IEnumerable<string> GetCommand();
}
