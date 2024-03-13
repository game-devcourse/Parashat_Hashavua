using UnityEngine;
using UnityEngine.InputSystem;


/**
 * This component allows the player to move by clicking the arrow keys.
 * The code was taken from https://www.youtube.com/watch?v=whzomFgjT50
 */

public class KeyBoardMoverSmoth : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed = 6;
    // public Camera mainCamera;

    private Vector2 movement;
    // private Vector3 cameraScale;
    private bool isFacingRight = false;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected Vector3 NewPosition() 
    {
        return rb.position + movement;
    }

    void Update()  {
        // cameraScale = mainCamera.transform.localScale;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        if (movement.x < 0 && isFacingRight) //if the left arrow is pressed and the object is facing right then it will face left
        {
            flip();
        }
        else if(movement.x > 0 && !isFacingRight) //if the right arrow is pressed and the object is facing left then it will face right
        {
           flip();
        }
    }

    protected void flip()
    {
        isFacingRight = !isFacingRight; //if facing right is true it will be false and if it is false it will be true
        transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y,1);
        // mainCamera.transform.localScale = cameraScale;
    }
}