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
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(passiveParticle, transform.position, passiveParticle.transform.rotation);
            timer = particleDelay;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        gameManager.moneyCollected += 100;
        Destroy(moneyPrefab);
    }
}
