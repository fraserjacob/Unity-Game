using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prototype : MonoBehaviour
{

    public int playerXSpeed = 7;
    public int playerYSpeed = 5;
    private bool facingRight = false;
    public int playerJumpPower = 1250;
    private float moveX;
    private float moveY;
    public bool hitWall = false;
    private CameraSystem cam;
    private float xEnterPosition;
    private float yEnterPosition;

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    // PlayerMove determins the direction and speed of movement
    void PlayerMove()
    {
        //controls
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        //player direction
        if (moveX < 0.0f && facingRight == false)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true)
        {
            FlipPlayer();
        }

        //movement
        gameObject.GetComponent<Rigidbody2D>().velocity =
        new Vector2(moveX * playerXSpeed, moveY * playerYSpeed);
    }

    // FlipPlayer turns the player around
    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    // Debuging log for collision
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Player has collided with " + col.collider.name);
    }

    // Events for when the player collides with certain things
    void OnTriggerStay2D(Collider2D col)
    {
        //teleports the player and makes a fixed camera when entering a room through a door
        if (col.tag == "Door" && Input.GetKeyDown("e"))
        {
            cam = Camera.main.GetComponent<CameraSystem>();
            cam.FixCamera(28.86921f, 18.79463f);

            Debug.Log("Player has collided with");
            xEnterPosition = gameObject.transform.position.x;
            yEnterPosition = gameObject.transform.position.y;
            gameObject.transform.position = new Vector3(28.8f, 14.4f, 0);
        }
        if (col.tag == "Exit Door" && Input.GetKeyDown("e"))
        {
            cam = Camera.main.GetComponent<CameraSystem>();
            cam.FreeCamera();
            Debug.Log("Player has collided with");
            gameObject.transform.position = new Vector3(xEnterPosition, yEnterPosition, 0);
        }
    }
}
