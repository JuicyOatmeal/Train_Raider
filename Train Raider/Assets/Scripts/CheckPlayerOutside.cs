using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerOutside : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other) // when the player goes on the roof of a carriage, set the isClimbing variable to true
    {
        playerController.isClimbing = true;
    }
}
