using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{
    public void WhenTriggerEnter(Collider other)
    {
        Debug.Log("when trigger enter");
    }
    
    public void WhenTriggerExit(Collider other)
    {
        Debug.Log("when trigger exit");
    }
}
