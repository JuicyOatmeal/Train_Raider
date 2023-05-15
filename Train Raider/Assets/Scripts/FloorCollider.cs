using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour
{
    PlayerController playerController;
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        playerController.FixPlayerPosEscaped(); // when the player enters the collider of the floor, call the FixPlayerPosEscaped() method in the PlayerController script
    }
}
