using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMoney : MonoBehaviour
{
    GameObject moneyPrefab;
    public GameManager gameManager;
    public ParticleSystem passiveParticle;
    float timer;
    float particleDelay = 0.4f;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        moneyPrefab = gameObject;
    }
    void Update()
    {
        timer -= Time.deltaTime; // timer goes down at a set speed
        if (timer <= 0) // if the timer is less than or equal to 0
        {
            Instantiate(passiveParticle, transform.position, passiveParticle.transform.rotation); // make a particle on top of the money
            timer = particleDelay; // reset the timer
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        gameManager.moneyCollected += 100; // add 100 to the moneyCollected variable inside the GameManager script
        Destroy(moneyPrefab); // destroy the money
    }
}
