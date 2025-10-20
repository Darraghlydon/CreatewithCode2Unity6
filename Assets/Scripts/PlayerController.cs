using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public float verticalInput;
    public float screenBoundaryValueX=18;
    public float screenBoundaryValueTop = 15;
    public float screenBoundaryValueBottom = -2;
    public float speed;
    
    
    private Transform playerTransform;
    public GameObject projectilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        HandleBoundaries();
        
        HandleInput();

        
    }

    private void HandleInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        playerTransform.Translate(Vector3.forward*(verticalInput * speed*Time.deltaTime));
        playerTransform.Translate(Vector3.right * (horizontalInput * speed * Time.deltaTime));
        
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
