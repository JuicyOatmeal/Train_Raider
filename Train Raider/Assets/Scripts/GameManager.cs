using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public MoveLeft moveLeft;
    public int moneyCollected;
    public bool fast;
    public bool gameOver;
    public bool win;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        win = false;
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
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
