using System.Collections.Generic;

class BetFactory
{
    private static NumberService numberService = NumberService.GetInstance();

    public static Bet GetBet(int value, int betValue)
    {
        List<Number> numbers = new List<Number>();
        int multiplier = 1;
        if (value < 37)
        {
            Number number = numberService.GetNumber(value);
            numbers.Add(number);
            multiplier = 36;
        }
        else if (value < 44)
        {
            Sector sector = Sector.GetSector(value);
            numbers = numberService.GetBySector(sector);
            multiplier = sector.Multiplier;
        }
        else if (value < 54)
        {
            Line color = Line.GetLine(value);
            numbers = numberService.GetByLine(color);
            multiplier = color.Multiplier;
        }
        else if (value < 63)
        {
            Color color = Color.GetColor(value);
            numbers = numberService.GetByColor(color);
            multiplier = color.Multiplier;
        }
        else if (value == 64)
        {
            numbers = numberService.Get1to18();
            multiplier = 2;
        }
        else if (value == 65)
        {
            numbers = numberService.GetEven();
            multiplier = 2;
        }
        else if (value == 66)
        {
            numbers = numberService.GetOdd();
            multiplier = 2;
        }
        else if (value == 67)
        {
            numbers = numberService.Get19to36();
            multiplier = 2;
        }
        return new Bet(numbers, betValue, multiplier);
    }
}
