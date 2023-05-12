using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheels : MonoBehaviour
{
    public GameObject wheel;
    public float rotateSpeed = 50;
    public Vector3 rotateDirection = new Vector3(10, 0, 0);

    void Start()
    {
        wheel = gameObject;
    }

    void Update() // rotates wheels at the rotateSpeed
    {
        wheel.transform.Rotate(rotateSpeed * rotateDirection * Time.deltaTime);
    }
}
