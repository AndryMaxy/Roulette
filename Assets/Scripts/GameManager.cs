using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

    private int baseBet = 0;
    public Text balanceText;
    public Text betText;
    public Text winText;
    public Text numberText;
    public Text historyText;
    public StatisticsManager statisticsManager;
    private NumberService numberService = NumberService.GetInstance();
    private HistoryRepository historyRepository;
    private List<int> history = new List<int>();
    private int historyCount;
    private int betSum;
    private int lastSpinBetSum;
    private List<Bet> bets = new List<Bet>();
    private List<Bet> lastBets = new List<Bet>();
    private List<int> lastCellsIds = new List<int>();
    private Cell[] cells;
    private Mailer mailManager;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        historyRepository = HistoryRepository.GetInstance();
        player = SaveManager.LoadPlayerData();

        if (player == null)
        {
            player = new Player(100000);
        }

        historyText.text = historyRepository.BuildHistoryString(60);
        int lastNumber = historyRepository.GetLastNumberValue();
        PrintNumber(lastNumber);
        balanceText.text = "Balance: " + player.Balance;
        betText.text = "Bet: " + 0;
        winText.text = "You won: " + 0;
        cells = FindObjectsOfType<Cell>();
    }

    public void Run()
    {
        int winSum = 0;
        winText.text = "You won: " + winSum;
        int random = UnityEngine.Random.Range(0, 36);
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

    private void PrintNumber(int value)
    {
        if (value < 0)
        {
            numberText.text = "-";
            return;
        }

        numberText.text = value.ToString();
        Number number = numberService.GetNumber(value);
        if (number.Color == Color.GREEN)
        {
            numberText.color = UnityEngine.Color.green;
        }
        else if (number.Color == Color.RED)
        {
            numberText.color = UnityEngine.Color.red;
        }
        else if (number.Color == Color.BLACK)
        {
            numberText.color = UnityEngine.Color.black;
        }
    }

    private void HandleHistory(int number)
    {
        historyRepository.SaveNumber(number);
        historyText.text = historyRepository.BuildHistoryString(50);
    }

    public void MakeBet(Bet bet)
    {
        betSum += bet.Value;
        bets.Add(bet);
        player.Balance -= bet.Value;
        balanceText.text = "Balance: " + player.Balance;
        betText.text = "Bet: " + betSum;
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
    }

    private void OnApplicationQuit()
    {
        SaveManager.SavePlayerData(player);
        historyRepository.SaveHistory();
    }
}
