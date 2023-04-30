using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MoveLeft moveLeft;
    public int moneyCollected;
    public bool fast;
    // Start is called before the first frame update
    void Start()
    {
        TrainSpeedSlow();
        Invoke("TrainSpeedFast", 15);
        Invoke("TrainSpeedSlow", 30);
        Invoke("TrainSpeedFast", 45);
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
