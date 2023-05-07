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
    public float amountToGoLeft = 40;
    public float amountToGoRight = 40;
    private float guardPosX;
    bool alarm;
    bool lookingLeft;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        player = GameObject.FindWithTag("Player");
        guard = this.gameObject;
        alarm = false;
        InvokeRepeating("DecideWhatToDo", 0, 4);
        StartCoroutine(ResetInts());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(player.transform.position, guard.transform.position));
        Debug.Log(lookingLeft);
        guardPosX = guard.transform.position.x;
        if ((lookingLeft = false && (Vector3.Distance(player.transform.position, guard.transform.position) <= 10)) || (guard.transform.rotation.y == 180 && (Vector3.Distance(player.transform.position, guard.transform.position) >= 10)))
        {
            Debug.Log("alarm");
        }
    }
    void GoLeft()
    {
        if (guard.transform.position.x > leftBound)
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
        if (guard.transform.position.x < rightBound)
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
        Invoke("LookLeft", 2);
        Invoke("LookRight", 3.5f);
        //Debug.Log("LookAround");
    }
    void DecideWhatToDo()
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
