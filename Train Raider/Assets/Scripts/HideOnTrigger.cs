using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnTrigger : MonoBehaviour
{
    public GameObject carriage;
    // Start is called before the first frame update
    void Start()
    {
        carriage = GetComponent<GameObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        carriage.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        carriage.SetActive(true);
    }
}
