using UnityEngine;

public class TrapScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);

        
        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided");
            other.gameObject.GetComponent<PlayerController>().Freeze();
            
            other.gameObject.SendMessage("Freeze");
        }
        Destroy(gameObject);
    }
}
