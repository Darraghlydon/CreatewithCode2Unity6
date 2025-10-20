using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spawnManager;

    private int playerLives = 3;
    public int playerScore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int valueToIncreaseBy)
    {
        playerScore += valueToIncreaseBy;
    }

    public void DecreaseLives()
    {
        playerLives--;
        
        if (playerLives <= 0)
        {
            spawnManager.SetActive(false);
            Debug.Log("Game Over! You got a score of "+playerScore);
        }
        else
        {
            Debug.Log("You have "+playerLives + " lives left.");
        }

    }
}
