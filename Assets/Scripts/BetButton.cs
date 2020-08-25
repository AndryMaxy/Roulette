using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetButton : MonoBehaviour
{

    public int bet;
    private GameManager gameManager;
    private Button button;
    private UnityEngine.Color baseNormalColor;
    private ColorBlock colors;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        button = GetComponent<Button>();
        colors = button.colors;
        baseNormalColor = colors.normalColor;
    }

    void Start()
    {
        //gameManager = FindObjectOfType<GameManager>();
        //button = GetComponent<Button>();
        //colors = button.colors;
        //baseNormalColor = colors.normalColor;
    }

    public void SetBet()
    {
        gameManager.SetBaseBet(bet);
        colors.normalColor = colors.selectedColor;
        button.colors = colors;
    }

    public void ResetColor()
    {
        colors.normalColor = baseNormalColor;
        button.colors = colors;
    }
}
