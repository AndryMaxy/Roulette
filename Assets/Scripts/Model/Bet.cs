using System.Collections.Generic;

public class Bet
{
    public List<Number> Numbers { get; }
    public int Value { get; }
    public int Multiplier { get; }

    public Bet(List<Number> numbers, int betValue, int multiplyer)
    {
        Numbers = numbers;
        Value = betValue;
        Multiplier = multiplyer;
    }
}
