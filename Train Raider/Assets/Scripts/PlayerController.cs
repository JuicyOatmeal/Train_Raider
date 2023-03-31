using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public GameObject player;
    public float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(forwardInput * Vector3.right * Time.deltaTime * -speed, Space.World);
        RotatePlayer();
    }

    void RotatePlayer()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            player.transform.eulerAngles = new Vector3(0, 270, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            player.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }

}
