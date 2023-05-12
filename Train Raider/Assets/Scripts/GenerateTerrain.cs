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
    void GenerateRandomPrefab() // randomly generates one of the prefabs in the terrainPrefabs[] 
    {
        int terrianIndex = Random.Range(0, terrianPrefabs.Length); // tells which terrainPrefab it should generate
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 10.3f); // sets the spawn position to spawnPos
        Instantiate(terrianPrefabs[terrianIndex], spawnPos, terrianPrefabs[terrianIndex].transform.rotation); // instantiate the randomly generated object at the spawnPos
        Invoke("GenerateRandomPrefab", repeatTime); // recalls the method so that it loops
    }
}
