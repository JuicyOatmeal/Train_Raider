using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject camera;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<GameObject>();
        player = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = player.transform.position;
    }
}
