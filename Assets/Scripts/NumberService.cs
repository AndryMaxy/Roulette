using System;
using System.Collections.Generic;

public class NumberService {

    private static NumberService instance = new NumberService();

    private List<Number> numbers;
    
    private NumberService(){
        numbers = initNumbers();
    }

    public static NumberService GetInstance() {
        return instance;
    }
    
    public Number GetNumber(int numberValue)
    {
        return NumberUtils.GetNumber(numbers, numberValue);
    }

    public List<Number> GetBySector(Sector sector) {
        return numbers.FindAll(number => number.Sector == sector);
    }

    public List<Number> GetByColor(Color color)
    {
        return NumberUtils.GetByColor(numbers, color);
    }

    public List<Number> GetByLine(Line line)
    {
        return numbers.FindAll(number => number.Line == line);
    }

    public List<Number> GetEven()
    {
        return NumberUtils.GetEven(numbers);
    }

    public List<Number> GetOdd()
    {
        return NumberUtils.GetOdd(numbers);
    }

    public List<Number> Get1to18()
    {
        return NumberUtils.Get1to18(numbers);
    }

    public List<Number> Get19to36()
    {
        return NumberUtils.Get19to36(numbers);
    }

    private List<Number> initNumbers() {
        List<Number> numbers = new List<Number>();
        Number number0 = new Number(Color.GREEN, Sector.NONE, Line.NONE, 0);
        Number number1 = new Number(Color.RED, Sector.FIRST, Line.BOT, 1);
        Number number2 = new Number(Color.BLACK, Sector.FIRST, Line.MID, 2);
        Number number3 = new Number(Color.RED, Sector.FIRST, Line.TOP, 3);
        Number number4 = new Number(Color.BLACK, Sector.FIRST, Line.BOT, 4);
        Number number5 = new Number(Color.RED, Sector.FIRST, Line.MID, 5);
        Number number6 = new Number(Color.BLACK, Sector.FIRST, Line.TOP, 6);
        Number number7 = new Number(Color.RED, Sector.FIRST, Line.BOT, 7);
        Number number8 = new Number(Color.BLACK, Sector.FIRST, Line.MID, 8);
        Number number9 = new Number(Color.RED, Sector.FIRST, Line.TOP, 9);
        Number number10 = new Number(Color.BLACK, Sector.FIRST, Line.BOT, 10);
        Number number11 = new Number(Color.BLACK, Sector.FIRST, Line.MID, 11);
        Number number12 = new Number(Color.RED, Sector.FIRST, Line.TOP, 12);

        Number number13 = new Number(Color.BLACK, Sector.SECOND, Line.BOT, 13);
        Number number14 = new Number(Color.RED, Sector.SECOND, Line.MID, 14);
        Number number15 = new Number(Color.BLACK, Sector.SECOND, Line.TOP, 15);
        Number number16 = new Number(Color.RED, Sector.SECOND, Line.BOT, 16);
        Number number17 = new Number(Color.BLACK, Sector.SECOND, Line.MID, 17);
        Number number18 = new Number(Color.RED, Sector.SECOND, Line.TOP, 18);
        Number number19 = new Number(Color.RED, Sector.SECOND, Line.BOT, 19);
        Number number20 = new Number(Color.BLACK, Sector.SECOND, Line.MID, 20);
        Number number21 = new Number(Color.RED, Sector.SECOND, Line.TOP, 21);
        Number number22 = new Number(Color.BLACK, Sector.SECOND, Line.BOT, 22);
        Number number23 = new Number(Color.RED, Sector.SECOND, Line.MID, 23);
        Number number24 = new Number(Color.BLACK, Sector.SECOND, Line.TOP, 24);

        Number number25 = new Number(Color.RED, Sector.THIRD, Line.BOT, 25);
        Number number26 = new Number(Color.BLACK, Sector.THIRD, Line.MID, 26);
        Number number27 = new Number(Color.RED, Sector.THIRD, Line.TOP, 27);
        Number number28 = new Number(Color.BLACK, Sector.THIRD, Line.BOT, 28);
        Number number29 = new Number(Color.BLACK, Sector.THIRD, Line.MID, 29);
        Number number30 = new Number(Color.RED, Sector.THIRD, Line.TOP, 30);
        Number number31 = new Number(Color.BLACK, Sector.THIRD, Line.BOT, 31);
        Number number32 = new Number(Color.RED, Sector.THIRD, Line.MID, 32);
        Number number33 = new Number(Color.BLACK, Sector.THIRD, Line.TOP, 33);
        Number number34 = new Number(Color.RED, Sector.THIRD, Line.BOT, 34);
        Number number35 = new Number(Color.BLACK, Sector.THIRD, Line.MID, 35);
        Number number36 = new Number(Color.RED, Sector.THIRD, Line.TOP, 36);

        numbers.Add(number0);
        numbers.Add(number1);
        numbers.Add(number2);
        numbers.Add(number3);
        numbers.Add(number4);
        numbers.Add(number5);
        numbers.Add(number6);
        numbers.Add(number7);
        numbers.Add(number8);
        numbers.Add(number9);
        numbers.Add(number10);
        numbers.Add(number11);
        numbers.Add(number12);
        numbers.Add(number13);
        numbers.Add(number14);
        numbers.Add(number15);
        numbers.Add(number16);
        numbers.Add(number17);
        numbers.Add(number18);
        numbers.Add(number19);
        numbers.Add(number20);
        numbers.Add(number21);
        numbers.Add(number22);
        numbers.Add(number23);
        numbers.Add(number24);
        numbers.Add(number25);
        numbers.Add(number26);
        numbers.Add(number27);
        numbers.Add(number28);
        numbers.Add(number29);
        numbers.Add(number30);
        numbers.Add(number31);
        numbers.Add(number32);
        numbers.Add(number33);
        numbers.Add(number34);
        numbers.Add(number35);
        numbers.Add(number36);
        return numbers;
    }
}
