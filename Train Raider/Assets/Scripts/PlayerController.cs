using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public GameObject player;
    public GameManager gameManager;
    public float verticalInput;
    public float forwardInput;
    public float leftBound;
    public float rightBound;
    public float playerPosX;
    public bool ableToClimb;
    public bool isClimbing;
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    void Update()
    {
        verticalInput = Input.GetAxis("Jump");
        forwardInput = Input.GetAxis("Vertical");
        Move();
    }
    void Move() 
    {
        if (gameManager.gameOver == false) // does this only if the game isn't over
        {
            if (player.transform.position.x < leftBound && player.transform.position.x > rightBound) // makes the player only able to move while they're inside the bounds of the train
            {
                transform.Translate(forwardInput * Vector3.right * Time.deltaTime * -speed, Space.World);
                RotatePlayer();
            }
            else if (player.transform.position.x > leftBound) // brings the player back into bounds if it goes outside
            {
                transform.Translate(Vector3.right * Time.deltaTime * -speed, Space.World);
            }
            else if (player.transform.position.x < rightBound) // brings the player back into bounds if it goes outside
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
            }
            Climb();
            FixPlayerPos();
        }
    }
    void RotatePlayer() // rotates the player based on which key is pressed
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            player.transform.eulerAngles = new Vector3(0, 270, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            player.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }
    void Climb() // moves the player up and down provided the player is ableToClimb
    {
        if (ableToClimb == true)
        {
            if (isClimbing == true)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    transform.Translate(verticalInput * Vector3.up * Time.deltaTime * speed, Space.World);
                }
            }
            else if (isClimbing == false)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    transform.Translate(verticalInput * Vector3.up * Time.deltaTime * speed, Space.World);
                }
            }
        }
    }
    
    public void FixPlayerPos() // if the player is at the wrong Y level when they stop being able to climb, set it to the correct level
    {
        if (ableToClimb == false)
        {
            if (isClimbing == true && ableToClimb == false)
            {
                Vector3 currentPosUp = new Vector3(transform.position.x, 9.5f, transform.position.z);
                player.transform.position = currentPosUp;
            }
            else if (isClimbing == false && ableToClimb == false)
            {
                Vector3 currentPosDown = new Vector3(transform.position.x, 5.9f, transform.position.z);
                player.transform.position = currentPosDown;
            }
        }
    }
}
