# 参考

## Stateパターンを使用しない場合

``` cs
public static class Program
{
    private enum State { Low, Middle, High }
    private State _state_ = Condition.Low;

    static void Increase()
    {
        if (_state == State.Low)
        {
            Console.WriteLine("温度を「中」に上げます。");
            _state++;
        }
        else if (_state == State.Middle)
        {
            Console.WriteLine("温度を「高」に上げます。");
            _state++;
        }
        else if (_state == State.High)
        {
            Console.WriteLine("これ以上温度を上げることはできません。");
        }
    }

    static void Decrease()
    {
        if (_state == State.Low)
        {
            Console.WriteLine("これ以上温度を下げることはできません。");
        }
        else if (_state == State.Middle)
        {
            Console.WriteLine("温度を「低」に下げます。");
            _state--;
        }
        else if (_state == State.High)
        {
            Console.WriteLine("温度を「中」に下げます。");
            _state--;
        }
    }

    public static void Main(string[] args)
    {
        Decrease(); // >> 温度を「低」に下げます。
        Decrease(); // >> これ以上温度を下げることはできません。
        Increase(); // >> 温度を「中」に上げます。
        Increase(); // >> 温度を「高」に上げます。
        Increase(); // >> これ以上温度を上げることはできません。
        Decrease(); // >> 温度を「中」に下げます。
        Decrease(); // >> 温度を「低」に下げます。
    }
}
```

## Stateパターンを使用した場合

``` cs
// State
public interface ITemperatureState {
    void Increase();
    void Decrease();
}
```

``` cs
// ConcreteState
public class HighTemperatureState : ITemperatureState {

    private HighTemperatureState() { }

    public static HighTemperatureState Instance { get; } = new HighTemperatureState();

    // Context
    AirConditioner airConditioner;

    public void Increase() {
        System.out.println("これ以上温度を上げることはできません。");
    }

    public void Decrease() {
        System.out.println("温度を「中」に下げます。");
        // 次に遷移する状態を「状態」自身が知っている
        airConditioner.setState(airConditioner.getMiddleState());
    }
}
```

``` cs
// Context
public class TemperatureContext {
    private ITemperatureState _state = new MiddleTemperatureState();

    public void IncreaseTemperature() {
        _state.increase();
    }

    public void DecreaseTemperature() {
        _state.decrease();
    }

    public void ChangeState(TemperatureState state) {
        _state = state;
    }
}
```

``` cs
public static class Program {
    public static void Main(string[] args)
    {
        var context = new TemplatureContext();

        context.Decrease(); // >> 温度を「低」に下げます。
        context.Decrease(); // >> これ以上温度を下げることはできません。
        context.Increase(); // >> 温度を「中」に上げます。
        context.Increase(); // >> 温度を「高」に上げます。
        context.Increase(); // >> これ以上温度を上げることはできません。
        context.Decrease(); // >> 温度を「中」に下げます。
        context.Decrease(); // >> 温度を「低」に下げます。
    }
}
```

<https://qiita.com/AsahinaKei/items/ce8e5d7bc375af23c719>
