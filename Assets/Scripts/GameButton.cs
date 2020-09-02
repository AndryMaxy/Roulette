using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButton : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Run()
    {
        gameManager.Run();
    }

    public void RepeatBet()
    {
        GetComponent<Button>().interactable = false;
        gameManager.SetLastSpinBet();
    }

    public void Cancel()
    {
        gameManager.RemoveLastBet();
    }

    public void CancelAll()
    {
        gameManager.RemoveAllBets();
    }
}
