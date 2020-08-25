using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetButtonController : MonoBehaviour
{
    public BetButton baseBetBtn;

    void Start()
    {
        baseBetBtn.SetBet();
    }

    //public int baseBetValue;
    //private BetButton[] betbuttons;

    //void Start()
    //{
    //    betbuttons = FindObjectsOfType<BetButton>();
    //    BetButton basebet = Array.Find(betbuttons, (btn) => btn.bet == baseBetValue);
    //    basebet.SetBet();
    //}
}
