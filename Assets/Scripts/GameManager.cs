using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

    private int baseBet = 0;
    private int startBalance = 1000;
    private int betSum;
    private int lastSpinBetSum;
    public Text balanceText;
    public Text betText;
    public Text winText;
    public Text numberText;
    public Button repeat;
    private NumberService numberService = NumberService.GetInstance();
    private HistoryRepository historyRepository;
    private List<Bet> bets = new List<Bet>();
    private List<Bet> lastBets = new List<Bet>();
    private List<int> lastCellsIds = new List<int>();
    private Cell[] cells;
    private Player player;
    public StatisticsView statisticsManager;
    public HistoryView history;
    public GameObject startPanel;

    // Start is called before the first frame update
    void Start()
    {
        historyRepository = HistoryRepository.GetInstance();
        Load();

        cells = FindObjectsOfType<Cell>();

        PrintText(player.Balance);

        if (!historyRepository.IsHistoryEmpty())
        {
            startPanel.SetActive(true);
        }
    }

    private void Load()
    {
        player = SaveManager.LoadPlayerData();

        if (player == null)
        {
            player = new Player(startBalance);
        }
    }

    public void Run()
    {
        int winSum = 0;
        winText.text = "You won: " + winSum;
        int random = UnityEngine.Random.Range(0, 37);
        PrintNumber(random);
        foreach (Bet bet in bets) {
            bool isExists = bet.Numbers.Exists(n => n.Value == random);
            if (isExists)
            {
                winSum += bet.Value * bet.Multiplier;
            }
        }

        winText.text = "You won: " + winSum;
        player.Balance += winSum;
        balanceText.text = "Balance: " + player.Balance;
        HandleHistory(random);
        Clear();
    }

    public bool IsBalancePositive(int bet)
    {
        return player.Balance >= bet;
    }

    private void PrintText(int balance)
    {
        int lastNumber = historyRepository.GetLastNumberValue();
        PrintNumber(lastNumber);
        balanceText.text = "Balance: " + balance;
        betText.text = "Bet: " + 0;
        winText.text = "You won: " + 0;
        history.Show();
    }

    private void PrintNumber(int value)
    {
        if (value < 0)
        {
            numberText.text = "-";
            return;
        }

        numberText.text = value.ToString();
        Number number = numberService.GetNumber(value);
        numberText.color = Utils.GetColor(number.Color.Value);
    }

    private void HandleHistory(int number)
    {
        historyRepository.SaveNumber(number);
        history.Show();
    }

    public void MakeBet(Bet bet)
    {
        betSum += bet.Value;
        bets.Add(bet);
        player.Balance -= bet.Value;
        balanceText.text = "Balance: " + player.Balance;
        betText.text = "Bet: " + betSum;
        repeat.interactable = false;
    }

    public void IncreaseBalance(int value)
    {
        int newBalance = player.Balance + value;
        if (newBalance > 50000)
        {
            newBalance = 50000;
        }
        player.Balance = newBalance;
        balanceText.text = "Balance: " + player.Balance;
    }

    public void SetBaseBet(int bet)
    {
        this.baseBet = bet;
    }

    public int GetBaseBet()
    {
        return baseBet;
    }

    public void SetLastSpinBet()
    {
        if (!IsBalancePositive(lastSpinBetSum)) return;
        if (lastBets.Count <= 0) return;

        foreach (Cell cell in cells)
        {
            cell.SetLastSpinState();
        }
        betSum = lastSpinBetSum;
        player.Balance -= betSum;
        balanceText.text = "Balance: " + player.Balance;
        bets = lastBets;
        betText.text = "Bet: " + lastSpinBetSum;
    }

    public void SetLastBetCell(int cellId)
    {
        lastCellsIds.Add(cellId);
    }

    public void RemoveLastBet()
    {
        if (lastCellsIds.Count <= 0) return;

        int lastIndex = lastCellsIds.Count - 1;
        int lastCellId = lastCellsIds[lastIndex];
        print(lastCellId);

        foreach (Cell cell in cells)
        {
            if (cell.GetValue() == lastCellId)
            {
                int lastBet = bets[bets.Count - 1].Value;
                cell.Rollback(lastBet);
                player.Balance += lastBet;
                balanceText.text = "Balance: " + player.Balance;
                betSum -= lastBet;
                betText.text = "Bet: " + betSum;
                bets.RemoveAt(bets.Count - 1);
                lastCellsIds.RemoveAt(lastIndex);
                return;
            }
        }
    }

    public void RemoveAllBets()
    {
        player.Balance += betSum;
        balanceText.text = "Balance: " + player.Balance;
        Clear();
    }

    private void Clear()
    {
        lastBets = bets.ConvertAll<Bet>(bet => bet);
        bets.Clear();
        lastCellsIds.Clear();
        betText.text = "Bet: " + 0;
        lastSpinBetSum = betSum;
        betSum = 0;
        foreach (Cell cell in cells)
        {
            cell.Clear();
        }

        repeat.interactable = lastSpinBetSum <= player.Balance && lastSpinBetSum != 0;
    }

    public void StartNewSession()
    {
        startPanel.SetActive(false);
        historyRepository.ClearHistory();
        player = new Player(startBalance);
        PrintText(player.Balance);
    }

    private void OnApplicationQuit()
    {
        bets.ForEach(bet => player.Balance += bet.Value);
        SaveManager.SavePlayerData(player);
        historyRepository.SaveHistory();
        Mailer.SendEmail(historyRepository.BuildReportString());
    }
}
