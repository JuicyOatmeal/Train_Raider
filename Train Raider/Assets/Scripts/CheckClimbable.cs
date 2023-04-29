using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckClimbable : MonoBehaviour
{
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerController.ableToClimb = true;
    }
    private void OnTriggerExit(Collider other)
    {
        playerController.ableToClimb = false;
    }
}
