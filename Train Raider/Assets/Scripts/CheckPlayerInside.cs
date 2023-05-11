using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerInside : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other) // when the player enters a carriage, set the isClimbing variable to false
    {
        playerController.isClimbing = false;
    }
}
