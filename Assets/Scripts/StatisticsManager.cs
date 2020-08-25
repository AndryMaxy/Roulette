using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatisticsManager : MonoBehaviour
{
    public TextMeshProUGUI spinCountText;
    public TextMeshProUGUI blackCountText;
    public TextMeshProUGUI redCountText;
    public TextMeshProUGUI greenCountText;
    public TextMeshProUGUI leftNumbersCountText;
    public TextMeshProUGUI rightNumbersCountText;
    public TextMeshProUGUI evenCountText;
    public TextMeshProUGUI oddCountText;

    private HistoryRepository historyRepository;

    void Start()
    {
        gameObject.SetActive(false);
        historyRepository = HistoryRepository.GetInstance();
        print("Start called for Statistics");
    }

    public void ShowStatistics()
    {
        print("statistics: " + historyRepository);
        spinCountText.text = "Count of spins: " + historyRepository.GetSpinCount();
        redCountText.text = "Count of Red: " + historyRepository.GetRedCount();
        blackCountText.text = "Count of Black: " + historyRepository.GetBlackCount();
        greenCountText.text = "Count of Zero: " + historyRepository.GetZeroCount();
        leftNumbersCountText.text = "Count of 1 to 18: " + historyRepository.Get1to18Count();
        rightNumbersCountText.text = "Count of 19 to 36: " + historyRepository.Get19to36Count();
        evenCountText.text = "Count of Even: " + historyRepository.GetEvenCount();
        oddCountText.text = "Count of Odd: " + historyRepository.GetOddCount();
    }
}
