using System;

[System.Serializable]
public class Color
{
    public static Color GREEN = new Color(60);
    public static Color RED = new Color(61);
    public static Color BLACK = new Color(62);

    public int Value { get; }
    public int Multiplier { get; }

    private Color(int value)
    {
        Value = value;
        Multiplier = 2;
    }

    public static Color GetColor(int value)
    {
        switch (value)
        {
            case 60: return GREEN;
            case 61: return RED;
            case 62: return BLACK;
            default: throw new NoFieldValueException();
        }
    }
}