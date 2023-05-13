using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheels : MonoBehaviour
{
    public GameObject wheel;
    GameManager gameManager;
    public Vector3 rotateDirection = new Vector3(10, 0, 0);

    void Start()
    {
        wheel = gameObject;
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update() // rotates wheels at the rotateSpeed
    {
        if (gameManager.fast == false)
        {
            wheel.transform.Rotate(20 * rotateDirection * Time.deltaTime);
        }
        else
        {
            wheel.transform.Rotate(40 * rotateDirection * Time.deltaTime);
        }
    }
}
