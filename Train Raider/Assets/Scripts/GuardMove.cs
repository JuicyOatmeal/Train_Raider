using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMove : MonoBehaviour
{
    public GameObject guard;
    public float leftBound;
    public float rightBound;
    public float speed = 10;
    private int intLeft;
    public float amountToGoLeft = 100;
    private int amountToGoRight;
    // Start is called before the first frame update
    void Start()
    {
        guard = this.gameObject;
        InvokeRepeating("DecideWhatToDo", 0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
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
                Debug.Log("GoLeft");
            }
        }
    }
    void GoRight()
    {
        if (guard.transform.position.x > rightBound)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
            LookRight();
            amountToGoRight++;
            Debug.Log("GoRight");
        }
    }
    void LookLeft()
    {
        guard.transform.eulerAngles = new Vector3(0, 90, 0);
    }
    void LookRight()
    {
        guard.transform.eulerAngles = new Vector3(0, 270, 0);
    }
    void LookAround()
    {
        Invoke("LookLeft", 2);
        Invoke("LookRight", 3.5f);
        Debug.Log("LookAround");
    }
    void DecideWhatToDo()
    {
        int choose = Random.Range(0, 3); //choose a number from 0-2
        if (choose == 0)
        {
            if (amountToGoLeft < 10)
            {
                GoLeft();
            }
        }
        else if (choose == 1)
        {
            if (amountToGoRight < 10)
            {
                GoRight();
            }
        }
        else if (choose == 2)
        {
            LookAround();
        }
    }
}
