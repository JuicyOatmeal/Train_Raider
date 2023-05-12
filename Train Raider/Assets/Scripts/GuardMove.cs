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
            intLeft++;
            if (intLeft < amountToGoLeft)
            {
                Invoke("GoLeft", 0);
                //Debug.Log("GoLeft");
            }
            if (intLeft >= amountToGoLeft)
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
            if (intRight < amountToGoRight)
            {
                Invoke("GoRight", 0);
                //Debug.Log("GoRight loop");
            }
            if (intRight >= amountToGoRight)
            {
                StartCoroutine(ResetInts());
            }
        }
    }
    void LookLeft() // makes the guard look left
    {
        guard.transform.eulerAngles = new Vector3(0, 90, 0);
        lookingLeft = true;
    }
    void LookRight() // makes the guard look right
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
        if (alarm == false) // if the alarm is set off, do a random one of 3 methods
        {
            int choose = Random.Range(0, 3);
            if (guardPosX < leftBound)
            {
                GoLeft();
            }
            else if (guardPosX > rightBound)
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
        if (player.transform.position.y - guard.transform.position.y <= 3)
        {
            if (distanceFromPlayer <= alarmRange)
            {
                if (lookingLeft == true && playerToLeft == true)
                {
                    alarm = true;
                }
                else if (lookingLeft = false && playerToLeft == false)
                {
                    alarm = true;
                }
            }
        }
    }
    IEnumerator ResetInts() // resets the ints which decide how long the player moves in a certain direction.
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
