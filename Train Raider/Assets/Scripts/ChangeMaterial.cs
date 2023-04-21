using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material[] materials;
    //private int _currentIndex = 0;
    public Renderer TargetRenderer;
    public GameObject carriage;
    // Start is called before the first frame update
    void Start()
    {
        //carriage = GameObject.FindWithTag("Carriage");
        carriage.GetComponent<Renderer>().material = materials[0];
    }


    private void OnTriggerEnter(Collider other)
    {
        carriage.GetComponent<Renderer>().material = materials[1];
        Debug.Log("triggerenter");
    }
    private void OnTriggerExit(Collider other)
    {
        carriage.GetComponent<Renderer>().material = materials[0];
        Debug.Log("triggerexit");
    }
}