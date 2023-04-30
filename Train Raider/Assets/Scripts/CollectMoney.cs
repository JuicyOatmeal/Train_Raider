using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMoney : MonoBehaviour
{
    GameObject moneyPrefab;
    public GameManager gameManager;
    public ParticleSystem passiveParticle;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        moneyPrefab = gameObject;
    }
    private void Update()
    {
        Instantiate(passiveParticle, transform.position, passiveParticle.transform.rotation);
    }
    private void OnTriggerEnter(Collider other)
    {
        gameManager.moneyCollected += 100;
        Destroy(moneyPrefab);
        Debug.Log("money collected");
    }
}
