using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatObject : MonoBehaviour
{
    
    public float repeatWidth;
    public GameObject objectToRepeat;
    public Vector3 startPos;

    void Start()
    {
        objectToRepeat = gameObject;
        startPos = transform.position;
        repeatWidth = objectToRepeat.GetComponent<BoxCollider>().size.x;
    }

    void Update()
    {
        if (objectToRepeat.transform.position.x > startPos.x + repeatWidth) // if the position of the object is past the repeat width, reset it's position to the starting position
        {
            transform.position = startPos;
        }
    }
}
