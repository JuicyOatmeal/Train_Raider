using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTerrain : MonoBehaviour
{
    public GameObject[] terrianPrefabs;
    public GameObject[] sceneryPrefabs;
    public float spawnPosX = -200;
    public float spawnPosY = 1.26f;
    public float spawnPosZ = 10.3f;
    public float currentLocationX;
    public float repeatTime;
    public float scenerySpawnPosX;
    public float sceneryLeftBound = 6;
    public float sceneryRightBound = 35;
    public float sceneryLeftBoundAlt = -4.5f;
    public float sceneryRightBoundAlt = -24;
    GameManager gameManager;
    PlayerController playerController;


    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        playerController = GameObject.FindObjectOfType<PlayerController>();
        Invoke("GenerateRandomTerrain", 0);
        Invoke("GenerateRandomScenery", 0);
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
    void GenerateRandomTerrain() // randomly generates one of the prefabs in the terrainPrefabs[] 
    {
        if (gameManager.win == false)
        {
            int terrianIndex = Random.Range(0, terrianPrefabs.Length); // tells which terrainPrefab it should generate
            Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ); // sets where the main terrain should spawn at spawnPos
            Instantiate(terrianPrefabs[terrianIndex], spawnPos, terrianPrefabs[terrianIndex].transform.rotation); // instantiate the randomly generated object at the spawnPos
            Vector3 spawnPosAlt = new Vector3(spawnPosX, spawnPosY, spawnPosZ + 37.7f); // sets where the main terrain should spawn at spawnPosAlt
            Instantiate(terrianPrefabs[terrianIndex], spawnPosAlt, terrianPrefabs[terrianIndex].transform.rotation); // instantiate the randomly generated object at the spawnPosAlt
            Invoke("GenerateRandomTerrain", repeatTime); // recalls the method so that it loops
        }
    }
    void GenerateRandomScenery() // randomly generates one of the prefabs in the sceneryPrefabs[] 
    {
        if (gameManager.win == false) 
        {
            int sceneryIndex = Random.Range(0, sceneryPrefabs.Length); //  tells which sceneryPrefab it should generate
            Vector3 spawnPos = new Vector3(scenerySpawnPosX, spawnPosY, Random.Range(sceneryLeftBound, sceneryRightBound)); // sets  the sceneryPrefab's spawnPos at a random place between the right and left bound
            Instantiate(sceneryPrefabs[sceneryIndex], spawnPos, sceneryPrefabs[sceneryIndex].transform.rotation); // instantiate the sceneryPrefab at spawnPos
            Vector3 spawnPosAlt = new Vector3(scenerySpawnPosX, spawnPosY, Random.Range(sceneryLeftBoundAlt, sceneryRightBoundAlt)); // sets  the sceneryPrefab's spawnPosAlt at a random place between the right and left bound
            Instantiate(sceneryPrefabs[sceneryIndex], spawnPosAlt, sceneryPrefabs[sceneryIndex].transform.rotation); // instantiate the sceneryPrefab at spawnPosAlt
            Invoke("GenerateRandomScenery", Random.Range(0.1f, 0.5f)); // recall the method after a time between 0.1 and 0.5 seconds
        }
    }
}
