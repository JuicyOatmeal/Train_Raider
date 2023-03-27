using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(0, 180, 0);
        }
        transform.Translate(0, 0, (forwardInput * Time.deltaTime * -speed));
    }
}
