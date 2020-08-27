using System;

[Serializable]
public class Number {
    public Color Color { get; }
    public int Value { get; }
    public Sector Sector { get; }
    public Line Line { get; }

    public Number(Color color, Sector sector, Line line, int value) {
        Color = color;
        Sector = sector;
        Line = line;
        Value = value;
    }
}
