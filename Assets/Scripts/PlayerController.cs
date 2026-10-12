using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{


    public float screenBoundaryValueX=18;
    public float screenBoundaryValueTop = 15;
    public float screenBoundaryValueBottom = -2;
    public float speed;

    public InputAction moveAction;
    private Transform playerTransform;
    public GameObject projectilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = transform;
        moveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        HandleBoundaries();
        
        HandleInput();
        
    }

    private void HandleInput()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        playerTransform.Translate(Vector3.forward*(moveInput.y * speed*Time.deltaTime));
        playerTransform.Translate(Vector3.right * (moveInput.x * speed * Time.deltaTime));
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    private void HandleBoundaries()
    {
        if (playerTransform.position.x < -screenBoundaryValueX)
        {
            playerTransform.position = new Vector3(-screenBoundaryValueX, playerTransform.position.y, playerTransform.position.z);
        }

        if (playerTransform.position.x > screenBoundaryValueX)
        {
            playerTransform.position = new Vector3(screenBoundaryValueX, playerTransform.position.y, playerTransform.position.z);
        }

        if (playerTransform.position.z > screenBoundaryValueTop)
        {
            playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, screenBoundaryValueTop);
            
        }

        if (playerTransform.position.z < screenBoundaryValueBottom)
        {
            playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, screenBoundaryValueBottom);
        }
    }
}
