using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float bound;
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.x > bound)
        {
            Destroy(gameObject);
        }
    }
}
