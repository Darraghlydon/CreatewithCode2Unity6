using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
