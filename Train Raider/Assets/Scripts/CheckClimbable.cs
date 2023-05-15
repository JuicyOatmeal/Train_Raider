using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckClimbable : MonoBehaviour
{
    public PlayerController playerController;

    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other) // when the player enters the collider sets ableToClimb in the PlayerController script to true
    {
        playerController.ableToClimb = true;
    }

    private void OnTriggerExit(Collider other) // when the player exits the collider, sets ableToClimb in the PlayerController script to false. Also runs FixPlayerPos() inside that script if the player isn't escaping
    {
        if (playerController.escaping != true)
        {
            playerController.ableToClimb = false;
            playerController.FixPlayerPos();
        }
    }
}
