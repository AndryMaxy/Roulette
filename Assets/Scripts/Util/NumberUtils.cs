using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class NumberUtils
{

    public static Number GetNumber(List<Number> numbers, int numberValue)
    {
        return numbers.Find(number => number.Value == numberValue);
    }

    public static List<Number> GetByColor(List<Number> numbers, Color color)
    {
        return numbers.FindAll(number => number.Color.Value == color.Value);
    }

    public static List<Number> GetEven(List<Number> numbers)
    {
        return numbers.FindAll(number => number.Value != 0 && number.Value % 2 == 0);
    }

    public static List<Number> GetOdd(List<Number> numbers)
    {
        return numbers.FindAll(number => number.Value != 0 && number.Value % 2 != 0);
    }

    public static List<Number> Get1to18(List<Number> numbers)
    {
        return numbers.FindAll(number => number.Value != 0 && number.Value < 19);
    }

    public static List<Number> Get19to36(List<Number> numbers)
    {
        return numbers.FindAll(number => number.Value > 18);
    }
}