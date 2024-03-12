using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component allows the player to move by clicking the arrow keys,
 * but only if the new position is on an allowed tile.
 */
public class KeyboardMoverByTile : KeyboardMover {
    [SerializeField] Tilemap tilemap = null;
    [SerializeField] AllowedTiles allowedTiles = null;

    private TileBase TileOnPosition(Vector3 worldPosition) {
        Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
        TileBase tile = tilemap.GetTile(cellPosition);
        if (tile != null) {
            return tile;
        }
        return null;
    }

    void Update() {
        Vector3 newPosition = NewPosition().Item1;
        TileBase tileOnNewPosition = TileOnPosition(newPosition);
        if (tileOnNewPosition != null && allowedTiles.Contains(tileOnNewPosition)) {
            transform.position = newPosition;
            // if (NewPosition().Item2 > 0)
            // {
            // //     transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Right arrow pressed, set rotation to (0, 0, 0)
            //     transform.localScale = new Vector3(1,1,1);
            // }
            // else if (NewPosition().Item2 < 0)
            // {
            // //     transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Left arrow pressed, set rotation to (0, 180, 0)
            //     transform.localScale = new Vector3(-1,1,1);
            // }
        } else {
            Debug.Log("You cannot walk on " + tileOnNewPosition + "!");
        }
    }
}


/**
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/**
 * This component allows the player to move by clicking the arrow keys,
 * but only if the new position is on an allowed tile.
 */
 /**
public class KeyboardMoverByTile : KeyboardMover {
    [SerializeField] Tilemap[] tilemaps = null;
    [SerializeField] AllowedTiles allowedTiles = null;

    private bool canWalkOn;
    private TileBase[] TileOnPosition(Vector3 worldPosition) {
        TileBase[] tilesB = new TileBase[tilemaps.Length];
        int index = 0;
        foreach (Tilemap tilemap in tilemaps) {
            Vector3Int cellPosition = tilemap.WorldToCell(worldPosition);
            TileBase tile = tilemap.GetTile(cellPosition);
            if (tile != null) {
               tilesB[index] = tile;
            }
        }
        return null;
    }

    void Update() {
        Vector3 newPosition = NewPosition().Item1;
        TileBase[] tileOnNewPosition = TileOnPosition(newPosition);
        canWalkOn = false;
        foreach(TileBase tile in tileOnNewPosition)
        {
            if (tile != null && allowedTiles.Contains(tile))
            {
                canWalkOn = true;
            }
            else
            {
                canWalkOn = false;
                break;
            }
        }
        if (canWalkOn) {
            transform.position = newPosition;
        //     if (NewPosition().Item2 > 0)
        //     {
        //         transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Right arrow pressed, set rotation to (0, 0, 0)
        //     }
        //     else if (NewPosition().Item2 < 0)
        //     {
        //         transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Left arrow pressed, set rotation to (0, 180, 0)
        //     }
        } else {
            Debug.Log("You cannot walk on " + tileOnNewPosition + "!");
        }
    }
}

**/