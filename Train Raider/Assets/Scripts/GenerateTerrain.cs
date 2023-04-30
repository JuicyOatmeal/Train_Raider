using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    public GameObject[] terrianPrefabs;
    public float spawnPosX = -200;
    public float spawnPosY = 1.26f;
    public float spawnPosZ = 10.3f;
    public float currentLocationX;
    public float repeatTime;
    GameManager gameManager;


    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        Invoke("GenerateRandomPrefab", 0);
    }

    void Update()
    {
        currentLocationX = gameObject.transform.position.x;
        if (gameManager.fast == true)
        {
            repeatTime = 1.3f;
        }
        else if (gameManager.fast == false)
        {
            repeatTime = 2.6f;
        }
    }
    void GenerateRandomPrefab()
    {
        int terrianIndex = Random.Range(0, terrianPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 10.3f);
        Instantiate(terrianPrefabs[terrianIndex], spawnPos, terrianPrefabs[terrianIndex].transform.rotation);
        Invoke("GenerateRandomPrefab", repeatTime);
    }
}
