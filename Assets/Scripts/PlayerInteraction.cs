using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform trophy;
    public Transform relevantSack;  // Reference to the relevant sack
    private bool isCarryingTrophy = false;

    void Update()
    {
        if (!isCarryingTrophy)
        {
            // Check for player input to pick up the trophy
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUpTrophy();
            }
        }
        else
        {
            // Check for player input to deposit the trophy
            if (Input.GetKeyDown(KeyCode.E))
            {
                DepositTrophy();
            }
        }
    }

    void PickUpTrophy()
    {
        // Check if the player is close to the trophy
        float distance = Vector3.Distance(transform.position, trophy.position);

        if (distance < 2f)
        {
            // Hide the trophy on the player
            trophy.SetParent(transform);  // Attach the trophy to the player
            trophy.gameObject.SetActive(false);
            isCarryingTrophy = true;
        }
    }

    void DepositTrophy()
    {
        // Check if the player is close to the relevant sack
        float distance = Vector3.Distance(transform.position, relevantSack.position);

        if (distance < 2f)
        {
            // Deposit the trophy into the relevant sack
            trophy.SetParent(null);  // Detach the trophy from the player
            trophy.position = relevantSack.position;
            trophy.gameObject.SetActive(true);
            isCarryingTrophy = false;
            Debug.Log("Trophy deposited in the relevant sack!");
            // Add any additional logic or events here
        }
    }
}