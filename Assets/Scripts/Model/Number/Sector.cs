using System;

[Serializable]
public class Sector  {

    public static Sector NONE = new Sector(40);
    public static Sector FIRST = new Sector(41);
    public static Sector SECOND = new Sector(42);
    public static Sector THIRD = new Sector(43);

    public int Value { get; }
    public int Multiplier { get; }

    private Sector(int value)
    {
        Value = value;
        Multiplier = 3;
    }

    public static Sector GetSector(int value)
    {
        switch (value)
        {
            case 40: return NONE;
            case 41: return FIRST;
            case 42: return SECOND;
            case 43: return THIRD;
            default: throw new NoFieldValueException();
        }
    }
}
