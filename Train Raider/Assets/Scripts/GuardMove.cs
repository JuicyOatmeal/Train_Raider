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
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        player = GameObject.FindWithTag("Player");
        guard = this.gameObject;
        alarm = false;
        InvokeRepeating("DecideWhatToDo", 0, 2f);
        StartCoroutine(ResetInts());
    }

    // Update is called once per frame
    void Update()
    {
        Alarm();
        FindPlayer();
        SetAmountToMove();
        distanceFromPlayer = Vector3.Distance(player.transform.position, guard.transform.position);
        guardPosX = guard.transform.position.x;
        
    }

    void SetAmountToMove()
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
    void FindPlayer()
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
    void GoLeft()
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
    void GoRight()
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
    void LookLeft()
    {
        guard.transform.eulerAngles = new Vector3(0, 90, 0);
        lookingLeft = true;
    }
    void LookRight()
    {
        guard.transform.eulerAngles = new Vector3(0, 270, 0);
        lookingLeft = false;
    }
    void LookAround()
    {
        Invoke("LookLeft", 0.5f);
        Invoke("LookRight", 2f);
        //Debug.Log("LookAround");
    }
    void DecideWhatToDo()
    {
        if (alarm == false)
        {
            int choose = Random.Range(0, 3); //choose a number from 0-2
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
        else if (alarm == true)
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

    void Alarm()
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

    IEnumerator ResetInts()
    {
        yield return new WaitForSeconds(2);
        intRight = 0;
        intLeft = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        gameManager.gameOver = true;
    }
}
