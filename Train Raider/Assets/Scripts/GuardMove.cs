using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMove : MonoBehaviour
{
    GameManager gameManager;
    public GameObject guard;
    public GameObject player;
    public float leftBound;
    public float rightBound;
    public float speed = 10;
    private int intLeft;
    private int intRight;
    public float amountToGoLeft;
    public float amountToGoRight;
    private float guardPosX;
    public bool alarm;
    public float alarmRange;
    bool lookingLeft;
    float distanceFromPlayer;
    public bool playerToLeft;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        player = GameObject.FindWithTag("Player");
        guard = this.gameObject;
        alarm = false;
        InvokeRepeating("DecideWhatToDo", 0, 2f); // starts the DecideWhatToDo script and call it every two seconds
        StartCoroutine(ResetInts()); // makes sure the ints which allow the guard to move are set correctly on start
    }
    void Update()
    {
        Alarm();
        FindPlayer();
        SetAmountToMove();
        distanceFromPlayer = Vector3.Distance(player.transform.position, guard.transform.position);
        guardPosX = guard.transform.position.x;
        
    }
    void SetAmountToMove() // makes the guard move further if the alarm is set off as is it is chasing the player
    {
        if (alarm == false)
        {
            amountToGoLeft = 300;
            amountToGoRight = 300; 
        }
        else if (alarm == true)
        {
            amountToGoLeft = 800;
            amountToGoRight = 800;
        }
    }
    void FindPlayer() // allows the guard to detect which side of the guard the player is on
    {
        if (player.transform.position.x - guardPosX >= 0)
        {
            playerToLeft = true;
        }
        else if (player.transform.position.x - guardPosX <= 0)
        {
            playerToLeft = false;
        }
    }
    void GoLeft() // makes the guard go left provided it is within the bounds of the train
    {
        if (guardPosX > leftBound)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
            LookLeft();
            intLeft++; // add one to this var every time the method is called
            if (intLeft < amountToGoLeft) // if intLeft hasn't been called at least amountToGoLeft times yet, call it again
            {
                Invoke("GoLeft", 0);
            }
            if (intLeft >= amountToGoLeft) // if intLeft has been called at least amountToGoLeft, don't recall GoLeft() and reset the intLeft
            {
                StartCoroutine(ResetInts());
            }
        }
    }
    void GoRight() // makes the guard go right provided it is within the bounds of the train
    {
        if (guardPosX < rightBound)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
            LookRight();
            intRight++;
            if (intRight < amountToGoRight) // if intRight hasn't been called at least amountToGoRight times yet, call it again
            {
                Invoke("GoRight", 0);
            }
            if (intRight >= amountToGoRight) // if intRight has been called at least amountToGoRight, don't recall GoRight() and reset the intRight
            {
                StartCoroutine(ResetInts());
            }
        }
    }
    void LookLeft() // makes the guard face left
    {
        guard.transform.eulerAngles = new Vector3(0, 90, 0);
        lookingLeft = true;
    }
    void LookRight() // makes the guard face right
    {
        guard.transform.eulerAngles = new Vector3(0, 270, 0);
        lookingLeft = false;
    }
    void LookAround() // makes the guard look around after a delay
    {
        Invoke("LookLeft", 0.5f);
        Invoke("LookRight", 2f);
        //Debug.Log("LookAround");
    }
    void DecideWhatToDo() // is called every 2 seconds, calls a method which makes the guard move
    {
        if (alarm == false) // if the alarm isn't set off, do a random one of 3 methods
        {
            int choose = Random.Range(0, 3);
            if (guardPosX < leftBound) // don't call a random method if the guard is outside of the train's bounds
            {
                GoLeft();
            }
            else if (guardPosX > rightBound) // don't call a random method if the guard is outside of the train's bounds
            {
                GoRight();
            }
            else
            {
                if (choose == 0)
                {
                    GoLeft();
                }
                else if (choose == 1)
                {
                    GoRight();
                }
                else if (choose == 2)
                {
                    LookAround();
                }
            }
        }
        else if (alarm == true) // if the alarm is set off, move in the direction of the player
        {
            if (playerToLeft == true)
            {
                GoLeft();
                //Invoke("DecideWhatToDo", 1);
            }
            else if (playerToLeft == false)
            {
                GoRight();
            }
        }
    }
    void Alarm() // makes alarm = true if the player is within detection radius
    {
        if (player.transform.position.y - guard.transform.position.y <= 3) // if the player is on the same Y level as the guard
        {
            if (distanceFromPlayer <= alarmRange) // if the guard is within alarmRange of the player
            {
                if (lookingLeft == true && playerToLeft == true) // if the guard is looking in the direction of the player
                {
                    alarm = true; // set off the alarm
                }
                else if (lookingLeft = false && playerToLeft == false) // if the guard is looking in the direction of the player
                {
                    alarm = true; // set off the alarm
                }
            }
        }
    }
    IEnumerator ResetInts() // resets the ints which decide how long the player moves in a certain direction after 2 seconds
    {
        yield return new WaitForSeconds(2); 
        intRight = 0;
        intLeft = 0;
    }
    private void OnTriggerEnter(Collider other) // if the player collides with the guard, make gameOver = true
    {
        gameManager.gameOver = true;
    }
}
