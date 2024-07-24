# Stateパターン

Stateパターンでは、「状態」をオブジェクトで表現する。

状態はStateクラスとして表現され、Contextクラスが保持し、その状態に基づく振る舞いをする。  

状態遷移（次にどの状態へなるか）は、各Stateオブジェクト自身が知っている（設計方法により、Contextオブジェクトが管理する場合もある）。  

Stateパターンは、オブジェクトの振る舞いがその「状態」に依存し、状態が変化することで振る舞いも変わる場合に有用。このパターンを使用すると、状態に基づく条件文（if-elseなど）を減少させ、コードの保守性と拡張性を向上させることができる。  

## GOFの定義

オブジェクトの内部状態が変化したときに，オブジェクトが振る舞いを変えるようにする。  
クラス内では，振る舞いの変化を記述せず，状態を表すオブジェクトを導入することでこれを実現する。  

## 書籍原文

状態遷移があるような場合に使える実装パターンです。  
何か状態が変わっていく、いくつかの状態で遷移するものです。  
例えばプリンターとかであれば、Ready状態があって、印刷準備中があって、印刷中がって、異常停止中になるかもしれないとか、「またReadyに戻って」という、決められた状態がありますよね。  
その決められた状態を遷移していくようなものの実装に使える実装パターンだと思ってください。  
従って実装としては、区分などで実装するのではなくて、クラスで状態を表現するというのがStateパターンの特徴になります。  
Stateというのは、日本語で「状態」という意味なので、オブジェクトで状態を表現するのがStateパターンということです。  
オブジェクト指向というのは、「モノ」をクラスにするという発想が多いのですけど、Stateパターンは、状態をクラスにするという実装をします。  
Ready状態や、印刷中など、そういった状態を、1個1個のクラスにしていくという考え方がStateパターンです。  

状態クラスが「その次の状態を知っている」というのがポイントになります。  
「この状態でこういうことされたら、次はこの状態になる」みたいなことを、各状態クラスに実装していくイメージになります。  
if文とかを多用して、状態を判断するのではなく、「状態自体が次の状態に遷移していく」といった実装になるわけです。  
従って、Stateパターンを使うと、状態ごとにクラスを作成するため、状態ごとの処理が整理され、それによって可読性が上がったり、プログラムを修正するときに、「ここを直せばいいのだなと」いうのがピンときたり、といった感じの保守性の高いプログラミングをすることができます。  
また、新しい「状態」を追加する場合なども、if文とかを駆使して書くやり方にくらべて，比較的簡単に実装追加を行うことができます。  

``` mermaid
stateDiagram
    待機中 --> 印刷準備中
    印刷準備中 --> 印刷中
    印刷中 --> 待機中

    異常停止中
```

## クラス図

``` mermaid
classDiagram
    class Context {
        - 現在の状態
    }
    class IState {
        <<interface>>
    }
    class OffState {
    }
    class LowState {
    }
    class HighState {
    }

    Context --> IState
    IState <|-- OffState
    IState <|-- LowState
    IState <|-- HighState
    Client --> Context
```

- IState：状態を同一視するためのインターフェイス。  
- ConcreteState：状態の具象クラス。状態の数だけ作る。次の状態を知っている。  
- Context：全体の制御を行うクラス。現在の状態を保持する。  
- Client：Contextを使用して機能を実現する。  

## Stateパターンを使用しない場合

``` cs
public partial class Form1 : Form
{
    private enum Condition { OFF, Low, High }
    private Condition _condition = Condition.OFF;

    public Form1()
    {
        InitializeComponent();
        StartPosition = FormStartPosition.CenterScreen;
    }

    private void UpButton_Click(object sender, EventArgs e)
    {
        string path = "heater.txt";
        if (_condition == Condition.OFF)
        {
         var list = new List<string>();
         list.Add("Low");
         list.Add("500W");
         File.WriteAllLines(path, list);
         _condition = Condition.Low;
        }
        else if(_condition== Condition.Low)
        {
         var list = new List<string>();
         list.Add("Hi");
         list.Add("1000W");
         File.WriteAllLines(path, list);
         _condition = Condition.High;
        }
        else if(_condition== Condition.High)
        {
         var list = new List<string>();
         list.Add("OFF");
         list.Add("0W");
         File.WriteAllLines(path, list);
         _condition = Condition.OFF;
        }
        else
        {
         throw new Exception("error");
        }

        DisplayLabel.Text = _condition.ToString();
    }
}
```

## Stateパターンを使用する場合

IState

``` cs
public interface IState{
    void UpState(Context context);
    string GetText();
    IEnumerable<string> GetCommand();
}
```

ConcreteState

``` cs
public class OffState : IState {
    public void UpState(Context context) {
        // 次はLowになりたい
        context.ChangeState(new LowState());
    }

    public string GetText() {
        return "OFF";
    }
    
    public IEnumerable<string> GetCommand() {
        return new List<string> {"Off", "0W"};
    }

}

public class LowState : IState {
    public void UpState(Context context) {
        // 次はHighになりたい
        context.ChangeState(new HighState());
    }

    public string GetText() {
        return "Low";
    }

    public IEnumerable<string> GetCommand() {
        return new List<string> {"Low", "500W"};
    }
}

public class HighState : IState {
    public void UpState(Context context) {
        // 次はOffになりたい
        context.ChangeState(new OffState());
    }

    public string GetText() {
        return "High";
    }

    public IEnumerable<string> GetCommand() {
        return new List<string> {"High", "1000W"};
    }
}
```

Context

``` cs
public class Context {
    // 現在の状態を持つ
    private IState _state = new OffState();

    // Clientに公開する窓口を作る
    public void Up() {
        _state.UpState(this);

        string path = "heater.txt";
        File.WriteAllLines(path, _state.GetCommand());
    }

    public string GetText() {
        return _state.GetText();
    }

    public void ChangeState(IState state) {
        _state = state;
    }
}
```

Client

``` cs
public partial class Form1 : Form
{
    private Context _context = new Context();

    public Form1()
    {
        InitializeComponent();
        StartPosition = FormStartPosition.CenterScreen;
        DisplayLabel.Text = _context.GetText();
    }

    private void UpButton_Click(object sender, EventArgs e)
    {
        _context.Up();
        DisplayLabel.Text = _context.GetText();
    }
}
```

## 出典

ピーコックアンダーソン  
デザインパターンC#：Stateパターン: わかりやすくて実践的なデザインパターン  
<https://www.amazon.co.jp/%E3%83%87%E3%82%B6%E3%82%A4%E3%83%B3%E3%83%91%E3%82%BF%E3%83%BC%E3%83%B3C-%EF%BC%9AState%E3%83%91%E3%82%BF%E3%83%BC%E3%83%B3-%E3%82%8F%E3%81%8B%E3%82%8A%E3%82%84%E3%81%99%E3%81%8F%E3%81%A6%E5%AE%9F%E8%B7%B5%E7%9A%84%E3%81%AA%E3%83%87%E3%82%B6%E3%82%A4%E3%83%B3%E3%83%91%E3%82%BF%E3%83%BC%E3%83%B3-%E3%83%94%E3%83%BC%E3%82%B3%E3%83%83%E3%82%AF%E3%82%A2%E3%83%B3%E3%83%80%E3%83%BC%E3%82%BD%E3%83%B3-ebook/dp/B0C49PVTLR/ref=sr_1_1?__mk_ja_JP=%E3%82%AB%E3%82%BF%E3%82%AB%E3%83%8A&crid=RNKQ3RLUVG9W&dib=eyJ2IjoiMSJ9.hGL8P4G8LGyO0GlaM0CbFw.RhSFUIit0KBvg7yeOxhlFWWnNrYJjau52vWh50MumY4&dib_tag=se&keywords=%E3%83%87%E3%82%B6%E3%82%A4%E3%83%B3%E3%83%91%E3%82%BF%E3%83%BC%E3%83%B3+%E3%83%94%E3%83%BC%E3%82%B3%E3%83%83%E3%82%AF%E3%82%A2%E3%83%B3%E3%83%80%E3%83%BC%E3%82%BD%E3%83%B3&qid=1721789922&sprefix=%E3%83%87%E3%82%B6%E3%82%A4%E3%83%B3%E3%83%91%E3%82%BF%E3%83%BC%E3%83%B3+%E3%83%94%E3%83%BC%E3%82%B3%E3%83%83%E3%82%AF%E3%82%A2%E3%83%B3%E3%83%80%E3%83%BC%E3%82%BD%E3%83%B3%2Caps%2C161&sr=8-1>

ソースコード  
<https://anderson02.com/Download/Tokuten/Heater_Fix.zip>

## 参考

<https://qiita.com/AsahinaKei/items/ce8e5d7bc375af23c719>
