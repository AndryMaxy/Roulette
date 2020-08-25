using System;

[Serializable]
public class Player
{
    public int Balance { get; set; }

    public Player()
    {

    }

    public Player(int balance)
    {
        Balance = balance;
    }
}