using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatObject : MonoBehaviour
{
    
    public float repeatWidth;
    public GameObject objectToRepeat;
    public Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = objectToRepeat.GetComponent<BoxCollider>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToRepeat.transform.position.x > startPos.x + repeatWidth)
        {
            transform.position = startPos;
            //Debug.Log("rail pos reset");
        }
    }
}
