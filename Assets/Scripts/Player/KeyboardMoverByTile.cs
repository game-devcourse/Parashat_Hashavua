using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component allows the player to move by clicking the arrow keys,
 * but only if the new position is on an allowed tile.
 */
public class KeyboardMoverByTile: KeyboardMover {
    [SerializeField] Tilemap tilemap = null;
    [SerializeField] AllowedTiles allowedTiles = null;
    // public float moveSpeed = 4f;


    private TileBase TileOnPosition(Vector3 worldPosition) {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        TileBase tile = tilemap.GetTile(cellPosition);
        if (tile != null) {
            return tile;
        }
        return null;
    }

    void Update()  {
        // cameraScale = mainCamera.transform.localScale;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Vector3 newPosition = NewPosition();
        TileBase tileOnNewPosition = TileOnPosition(newPosition);
        if (allowedTiles.Contains(tileOnNewPosition) && moveAction.WasPerformedThisFrame()) {
            //transform.Translate(newPosition * moveSpeed * Time.deltaTime, Space.World);
            transform.position = newPosition;
        } 
        // else {
        //     Debug.Log("You cannot walk on " + tileOnNewPosition + "!");
        // }
        if (movement.x < 0 && isFacingRight) //if the left arrow is pressed and the object is facing right then it will face left
        {
            flip();
        }
        else if(movement.x > 0 && !isFacingRight) //if the right arrow is pressed and the object is facing left then it will face right
        {
           flip();
        }
    }
}