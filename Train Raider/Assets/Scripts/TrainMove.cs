using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMove : MonoBehaviour
{
    PlayerController playerController;
    MoveLeft moveLeft;
    void Start()
    {
        moveLeft = GameObject.FindObjectOfType<MoveLeft>();
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (playerController.escaping == true) // if the player has escaped, make the train start moving at the speed from the MoveLeft script
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveLeft.speed);
        }
    }
}
