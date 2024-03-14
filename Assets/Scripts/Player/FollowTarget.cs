using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target; // The object to follow
    public float followSpeed = 5f; // The speed at which this object follows the target
    public float lagDistance = 2f; // The distance behind the target where this object lags

    private Vector3 lastTargetPosition; // The last position of the target
    private bool canFollow = false;

    void Start()
    {
        // Initialize the last target position to the current target position
        lastTargetPosition = target.position;
    }

    public void Follow()
    {
        canFollow = true;
    }

    void Update()
    {
        if(canFollow)
        {
            // Check if the target is not null
            if (target != null)
            {
                // Calculate the direction to the target
                Vector3 direction = target.position - transform.position;

                // Calculate the distance to the target
                float distance = direction.magnitude;

                // Normalize the direction to get a unit vector
                direction.Normalize();

                // Move towards the target with a lag
                transform.position += direction * followSpeed * Time.deltaTime;
                transform.position = Vector3.Lerp(transform.position, target.position - direction * lagDistance, followSpeed * Time.deltaTime);

                // Check if the target has moved
                if (target.position != lastTargetPosition)
                {
                    // Calculate the target's movement direction
                    Vector3 targetDirection = target.position - lastTargetPosition;

                    // Rotate this object to face the same direction as the target
                    transform.rotation = Quaternion.LookRotation(targetDirection);
                }

                // Update the last target position
                lastTargetPosition = target.position;
            }
        }
    }
}
