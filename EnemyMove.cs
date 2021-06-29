using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{

    public int EnemySpeed;
    public int XMoveDirection;
    public int EnemySpread;
    private float maxPos;
    private float minPos;
    private bool started = true;

    // Update is called once per frame
    void Update()
    {

        //initialise enemy hit raycasts and set velocity
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.up);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position, Vector2.down);

        //movement
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        
        //sets the initial enemy movement spread based on starting position
        if (started == true)
        {
            started = false;
            maxPos = gameObject.transform.position.x + EnemySpread;
            minPos = gameObject.transform.position.x - EnemySpread;
        }
        
        //flips the enemy if they pass their maximum or minimum spread values
        if (gameObject.transform.position.x > maxPos)
        {
            Flip();
            gameObject.transform.position = new Vector3(maxPos-0.1f, gameObject.transform.position.y, 0);   
        }
        if (gameObject.transform.position.x < minPos)
        {
            Flip();
            gameObject.transform.position = new Vector3(minPos+0.1f, gameObject.transform.position.y, 0);
            
        }

        // Checks if raycasts have hit anything then kills player if so
        if (hit && hit.distance < 1.7f && hit.collider.tag == "Player")
        {
            //SceneManager.LoadScene("2d prototype");
            Destroy(hit.collider.gameObject);
        }
        if (hit2 && hit2.distance < 1.7f && hit2.collider.tag == "Player")
        {
            //SceneManager.LoadScene("2d prototype");
            Destroy(hit2.collider.gameObject);
        }
        if (hit3 && hit3.distance < 1.5f && hit3.collider.tag == "Player")
        {
            //SceneManager.LoadScene("2d prototype");
            Destroy(hit3.collider.gameObject);
        }


    }
    
    // Flip switches the enemy's movement direction
    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }
}


