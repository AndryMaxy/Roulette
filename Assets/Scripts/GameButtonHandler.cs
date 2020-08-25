using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonHandler : MonoBehaviour
{

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run()
    {
        gameManager.Run();
    }

    public void RepeatBet()
    {
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
