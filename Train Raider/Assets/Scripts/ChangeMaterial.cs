using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public Material[] materials; // makes an array named materials
    public Renderer TargetRenderer;
    public GameObject carriage;
    void Start()
    {
        carriage.GetComponent<Renderer>().material = materials[0]; // before the first frame, set the carriages material to solid
    }

    private void OnTriggerEnter(Collider other) // when the player enters the carriage, set the material to transparent
    {
        carriage.GetComponent<Renderer>().material = materials[1];
    }

    private void OnTriggerExit(Collider other) // when the player exits the carriage, set the material to solid
    {
        carriage.GetComponent<Renderer>().material = materials[0];
    }
}