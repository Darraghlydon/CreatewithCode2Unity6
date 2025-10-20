using UnityEngine;

public class DestroyOutofBounds : MonoBehaviour
{
    private float topBound = 30; 
    
    private float bottomBound = -10;
    private float leftBound = -30;
    private float rightBound = 30;
    private GameManager gameManager;
    private Transform myTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myTransform = transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myTransform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (myTransform.position.z < bottomBound)
        {
            gameManager.DecreaseLives();
            Destroy(gameObject);
        }

        if (myTransform.position.x < leftBound || myTransform.position.x > rightBound)
        {
            gameManager.DecreaseLives();
            
        }
    }
}
