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
        return history.Numbers.GetRange(index, count);
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


    public string BuildHistoryString(int count)
    {
        List<Number> shownNumbers = GetLastHistoryNumbers(count);
        shownNumbers.Reverse();
        string historyStr = "";
        shownNumbers.ForEach(n =>
        {
            historyStr += " " + n.Value.ToString() + "| ";
        });
        return historyStr;
    }

    public void SaveHistory()
    {
        SaveManager.SaveHistoryData(history);
    }
}
