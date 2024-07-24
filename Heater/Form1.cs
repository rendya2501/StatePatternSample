using Heater.Context;

namespace Heater;

public partial class Form1 : Form
{
    private readonly HeaterContext _context = new();

    public Form1()
    {
        InitializeComponent();
        StartPosition = FormStartPosition.CenterScreen;

        Context_StateChanged();
        // 状態変更の通知を受信する
        _context.StateChanged += Context_StateChanged;
    }

    private void Context_StateChanged()
    {
        DisplayLabel.Text = _context.GetText();
    }

    /// <summary>
    /// Upボタン
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param> <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void UpButton_Click(object sender, EventArgs e)
    {
        // Upをべた書きした場合のロジック
        //string path = "heater.txt";
        //if (_condition == Condition.OFF)
        //{
        //  var list = new List<string>();
        //  list.Add("Low");
        //  list.Add("500W");
        //  File.WriteAllLines(path, list);
        //  _condition = Condition.Low;
        //}
        //else if(_condition== Condition.Low)
        //{
        //  var list = new List<string>();
        //  list.Add("Hi");
        //  list.Add("1000W");
        //  File.WriteAllLines(path, list);
        //  _condition = Condition.High;
        //}
        //else if(_condition== Condition.High)
        //{
        //  var list = new List<string>();
        //  list.Add("OFF");
        //  list.Add("0W");
        //  File.WriteAllLines(path, list);
        //  _condition = Condition.OFF;
        //}
        //else
        //{
        //  throw new Exception("error");
        //}

        _context.Up();
    }

    /// <summary>
    /// Downボタン
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DownButton_Click(object sender, EventArgs e)
    {
        _context.Down();
    }

    /// <summary>
    /// On/Offボタン
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnOffButton_Click(object sender, EventArgs e)
    {
        _context.OnOff();
    }

    /// <summary>
    /// Maxボタン
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MaxButton_Click(object sender, EventArgs e)
    {
        _context.Max();
    }
}
