using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30;
    public float rightBound = -100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        //if (transform.position.x < rightBound && gameObject.CompareTag("Track"))
        {
            //Destroy(gameObject);
            //Debug.Log("destroyed rail");
        }
    }
}