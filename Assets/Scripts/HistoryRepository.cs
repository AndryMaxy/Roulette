using System.Collections.Generic;
using System.Linq;

class HistoryRepository
{
    private static HistoryRepository instance = new HistoryRepository();
    private NumberService numberService = NumberService.GetInstance();

    private History history;

    private HistoryRepository() {
        history = SaveManager.LoadHistoryData();
        if (history == null)
        {
            history = new History();
        }
    }

    public static HistoryRepository GetInstance()
    {
        return instance;
    }

    public void SaveNumber(int numberValue)
    {
        history.Numbers.Add(numberService.GetNumber(numberValue));
    }

    public int GetSpinCount()
    {
        return history.Numbers.Count;
    }

    public int GetRedCount()
    {
        return NumberUtils.GetByColor(history.Numbers, Color.RED).Count;
    }

    public int GetBlackCount()
    {
        return NumberUtils.GetByColor(history.Numbers, Color.BLACK).Count;
    }

    public int GetZeroCount()
    {
        return NumberUtils.GetByColor(history.Numbers, Color.GREEN).Count;
    }

    public int Get1to18Count()
    {
        return NumberUtils.Get1to18(history.Numbers).Count;
    }

    public int Get19to36Count()
    {
        return NumberUtils.Get19to36(history.Numbers).Count;
    }

    public int GetEvenCount()
    {
        return NumberUtils.GetEven(history.Numbers).Count;
    }

    public int GetOddCount()
    {
        return NumberUtils.GetOdd(history.Numbers).Count;
    }

    public List<Number> GetLastHistoryNumbers(int count)
    {
        int numbersCount = history.Numbers.Count;
        int index = numbersCount - count;
        if (index < 0)
        {
            index = 0;
        }

        if (numbersCount < count)
        {
            count = history.Numbers.Count;
        }
        List<Number> lastNumbers = history.Numbers.GetRange(index, count);
        lastNumbers.Reverse();
        return lastNumbers;
    }
    public int GetLastNumberValue()
    {
        int numbersCount = history.Numbers.Count;

        if (numbersCount == 0)
        {
            return -1;
        }
        return history.Numbers[numbersCount - 1].Value;
    }

    public void SaveHistory()
    {
        SaveManager.SaveHistoryData(history);
    }

    public bool IsHistoryEmpty()
    {
        return history.Numbers.Count == 0;
    }

    public void ClearHistory()
    {
        history.Numbers.Clear();
    }

    public string BuildReportString()
    {
        return $"Count of spins: {GetSpinCount()}\n" +
            $"Count of Red: {GetRedCount()}\n" +
            $"Count of Black: {GetBlackCount()}\n" +
            $"Count of Zero: {GetZeroCount()}\n" +
            $"Count of 1 to 18: {Get1to18Count()}\n" +
            $"Count of 19 to 36: {Get19to36Count()}\n" +
            $"Count of Even: {GetEvenCount()}\n" +
            $"Count of Odd: {GetOddCount()}";
    }
}
