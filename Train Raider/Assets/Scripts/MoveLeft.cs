using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30;
    public float rightBound = -100;
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update() 
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed); // move left at a certain speed
        // set the speed based on the GameManager script
        if (gameManager.fast == true) 
        {
            speed = 20;
        }
        else if (gameManager.fast == false)
        {
            speed = 10;
        }
    }
}
