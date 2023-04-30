using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMoney : MonoBehaviour
{
    GameObject moneyPrefab;
    public GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        moneyPrefab = gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        gameManager.moneyCollected += 100;
        Destroy(moneyPrefab);
        Debug.Log("money collected");
    }
}
