using UnityEngine;
using UnityEngine.InputSystem;


/**
 * This component allows the player to move by clicking the arrow keys.
 */
public class KeyboardMover : MonoBehaviour {

    [SerializeField] protected InputAction moveAction;
    // public Camera mainCamera;
    protected Vector2 movement;
    protected bool isFacingRight = false;
    public float moveSpeed = 5f;
    // protected Vector3 cameraScale;

    void OnValidate() {
        // Provide default bindings for the input actions.
        // Based on answer by DMGregory: https://gamedev.stackexchange.com/a/205345/18261
        if (moveAction == null)
            moveAction = new InputAction(type: InputActionType.Button);
        if (moveAction.bindings.Count == 0)
            moveAction.AddCompositeBinding("2DVector")
                .With("Up", "<Keyboard>/upArrow")
                .With("Down", "<Keyboard>/downArrow")
                .With("Left", "<Keyboard>/leftArrow")
                .With("Right", "<Keyboard>/rightArrow");
    }

    private void OnEnable() {
        moveAction.Enable();
    }

    private void OnDisable() {
        moveAction.Disable();
    }

    protected Vector3 NewPosition() {
        Vector3 movement = moveAction.ReadValue<Vector2>(); // Implicitly convert Vector2 to Vector3, setting z=0.
        return movement;
    }

    void Update()  {
        transform.position += NewPosition() * moveSpeed * Time.deltaTime;
    
        // Check if the object needs to be flipped
        if (NewPosition().x < 0 && isFacingRight) //if the left arrow is pressed and the object is facing right then it will face left
        {
            flip();
        }
        else if(NewPosition().x > 0 && !isFacingRight) //if the right arrow is pressed and the object is facing left then it will face right
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