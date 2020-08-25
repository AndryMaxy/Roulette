using System;

[Serializable]
public class Line
{

    public static Line NONE = new Line(50);
    public static Line TOP = new Line(51);
    public static Line MID = new Line(52);
    public static Line BOT = new Line(53);

    public int Value { get; }
    public int Multiplier { get; }

    private Line(int value)
    {
        Value = value;
        Multiplier = 3;
    }

    public static Line GetLine(int value)
    {
        switch (value)
        {
            case 50: return NONE;
            case 51: return TOP;
            case 52: return MID;
            case 53: return BOT;
            default: throw new NoFieldValueException();
        }
    }
}

