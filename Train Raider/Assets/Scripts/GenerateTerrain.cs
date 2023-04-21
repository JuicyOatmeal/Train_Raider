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
    public float repeatTime = 1.3f;


    void Start()
    {
        InvokeRepeating("GenerateRandomPrefab", 0f, repeatTime);
    }

    void Update()
    {
        currentLocationX = gameObject.transform.position.x;
    }
    void GenerateRandomPrefab()
    {
        int terrianIndex = Random.Range(0, terrianPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 10.3f);
        Instantiate(terrianPrefabs[terrianIndex], spawnPos, terrianPrefabs[terrianIndex].transform.rotation);
    }
}
