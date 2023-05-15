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
        TrainSpeedSlow(); // sets the train's speed to slow
        Invoke("TrainSpeedFast", 15); // sets the train's speed to fast after the game has been going for 15 seconds
        Invoke("TrainSpeedSlow", 30); // sets the train's speed to slow after the game has been going for 30 seconds
        Invoke("TrainSpeedFast", 45); // sets the train's speed to fast after the game has been going for 45 seconds
        Invoke("TrainSpeedSlow", 60); // sets the train's speed to slow after the game has been going for 60 seconds
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
            cantJumpText.gameObject.SetActive(true); // if the player tried to escape from the train at a time where they aren't allowed show the cantJumpText
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
    void TrainSpeedFast() // sets the train speed (for use in other scripts)
    {
        fast = true;
    }
    void TrainSpeedSlow() // sets the train speed (for use in other scripts)
    {
        fast = false;
    }
}
