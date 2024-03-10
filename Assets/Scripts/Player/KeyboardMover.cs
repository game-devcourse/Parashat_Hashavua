﻿using UnityEngine;
using UnityEngine.InputSystem;


/**
 * This component allows the player to move by clicking the arrow keys.
 */
public class KeyboardMover : MonoBehaviour {

    [SerializeField] InputAction moveAction;

    private float rotationWay;

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

    protected (Vector3, float) NewPosition() {
        if (moveAction.WasPerformedThisFrame()) {
            Vector3 movement = moveAction.ReadValue<Vector2>(); // Implicitly convert Vector2 to Vector3, setting z=0.
            return (transform.position + movement, movement.x);
        } else {
            return (transform.position, rotationWay);
        }
    }


    void Update()  {
        var positionOut = NewPosition();
        transform.position = positionOut.Item1;
        rotationWay = positionOut.Item2;
        if (rotationWay > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if (rotationWay < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

    }
}
