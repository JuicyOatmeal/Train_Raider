using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerInside : MonoBehaviour
{
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        playerController.isClimbing = false;
    }
}
