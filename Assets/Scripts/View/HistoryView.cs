using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HistoryView : MonoBehaviour
{
    public Text historyText;
    private HistoryRepository repository = HistoryRepository.GetInstance();
    private List<Number> shownNumbers;

    public void Start()
    {
        historyText.text = "";
        shownNumbers = repository.GetLastHistoryNumbers(60);
    }

    public void ShowHistory(int number)
    {
        repository.SaveNumber(number);
        if (repository.GetSpinCount() > 60)
        {
            shownNumbers.RemoveAt(60);
        }
        string historyStr = "";
        shownNumbers.ForEach(n =>
        {
            historyStr += " " + n.ToString() + "| ";
        });
        historyText.text = historyStr;
    }

}
