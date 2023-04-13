using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheels : MonoBehaviour
{
    public GameObject wheel;
    public float rotateSpeed = 50;
    public Vector3 rotateDirection = new Vector3(10, 0, 0); 
    // Start is called before the first frame update
    void Start()
    {
        wheel = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        wheel.transform.Rotate(rotateSpeed * rotateDirection * Time.deltaTime);
    }
}
