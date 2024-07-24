using Heater.Context;

namespace Heater.States;

/// <summary>
/// 状態を同一視するためのインタフェース
/// </summary>
public interface IHeaterState
{
    void UpState(HeaterContext context);

    void DownState(HeaterContext context);

    void OnOffState(HeaterContext context);

    /// <summary>
    /// 各状態の文字列を取得する
    /// </summary>
    /// <returns></returns>
    string GetText();

    /// <summary>
    /// ファイル出力用のコマンド文字列を取得する
    /// </summary>
    /// <returns></returns>
    IEnumerable<string> GetCommand();
}
