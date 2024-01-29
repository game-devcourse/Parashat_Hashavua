using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MouseClick : MonoBehaviour
{
    //this answere relies on https://kylewbanks.com/blog/unity-2d-detecting-gameobject-clicks-using-raycasts
    [SerializeField] string sceneName;
    [SerializeField] string triggeringTag;
    [SerializeField] InputAction click;

    private void OnEnable()
    {
        click.Enable();
    }

    private void OnDisable()
    {
        click.Disable();
    }

    private void Update()
    {
        if (click.triggered)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 rayOrigin = new Vector2(mousePosition.x, mousePosition.y);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero);


            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag(triggeringTag))
                {
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
    }
}