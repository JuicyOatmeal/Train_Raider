using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public MoveLeft moveLeft;
    public PlayerController playerController;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI cantJumpText;
    public TextMeshProUGUI youWinText;
    public int moneyCollected;
    public bool fast;
    public bool gameOver;
    public bool win;
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
        win = false;
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
        youWinText.gameObject.SetActive(false);
        TrainSpeedSlow();
        Invoke("TrainSpeedFast", 15);
        Invoke("TrainSpeedSlow", 30);
        Invoke("TrainSpeedFast", 45);
        Invoke("TrainSpeedSlow", 60);
    }
    void Update()
    {
        moneyText.text = "Collected: " + moneyCollected;
        gameOverText.text = "GAME OVER";
        if (gameOver == true)
        {
            gameOverText.gameObject.SetActive(true);
        }

        if (playerController.triedJump == true)
        {
            cantJumpText.gameObject.SetActive(true);
        }
        else
        {
            cantJumpText.gameObject.SetActive(false);
        }

        if (win == false)
        {
            youWinText.gameObject.SetActive(false);
            moneyText.gameObject.SetActive(true);
        }
        else if (win == true)
        {
            moneyText.gameObject.SetActive(false);
            youWinText.text = "You escaped with " + moneyCollected + " dollars collected!";
            youWinText.gameObject.SetActive(true);
        }
    }
    void TrainSpeedFast()
    {
        fast = true;
    }
    void TrainSpeedSlow()
    {
        fast = false;
    }
}
