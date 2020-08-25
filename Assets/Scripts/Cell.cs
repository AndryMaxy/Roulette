using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{

    public int value;
    public Image image;
    public Text text;
    public int maxBet = 400;
    public int minBet = 1;
    private int cellBet = 0;
    private int lastSpinBet = 0;

    private GameManager gameManager;

    public Cell()
    {

    }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void MakeBet()
    {
        if (cellBet == maxBet) return;

        int currentBet = gameManager.GetBaseBet();
        int newBet = cellBet + currentBet;
 
        if (newBet > maxBet)
        {
            currentBet = maxBet - cellBet;
            newBet = maxBet;
        } else if (newBet < minBet)
        {
            currentBet = minBet;
            newBet = minBet;
        }
        cellBet = newBet;
        print("nubmer clicked: " + value);
        image.gameObject.SetActive(true);
        text.text = cellBet.ToString();
        Bet bet = BetFactory.GetBet(value, currentBet);
        gameManager.MakeBet(bet);
        gameManager.SetLastBetCell(value);
    }

    public void Rollback(int bet)
    {
        cellBet -= bet;
        text.text = cellBet.ToString();
        if (cellBet <= 0)
        {
            image.gameObject.SetActive(false);
        }
    }

    public void Clear()
    {
        image.gameObject.SetActive(false);
        text.text = "";
        lastSpinBet = cellBet;
        cellBet = 0;
    }

    public void SetLastSpinState()
    {
        if (lastSpinBet > 0)
        {
            image.gameObject.SetActive(true);
            cellBet = lastSpinBet;
            text.text = cellBet.ToString();
        }
    }

    public int GetValue()
    {
        return value;
    }
}
