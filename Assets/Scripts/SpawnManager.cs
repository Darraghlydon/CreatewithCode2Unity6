using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float startDelay = 1.5f;
    private float spawnRate = 2f; 
    private float spawnRangeX = 18;
    private float spawnRangeZ = 15;
    private float offScreenSpawnPosition = 20;
    private Vector3 spawnPos;
    private Quaternion spawnRot;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        
    }

    private void SpawnRandomAnimal()
    {
         int spawnPosition = Random.Range(0, 3);
         switch (spawnPosition)
         {
             case 0:
             {
                 //This is when animals spawn from the left hand side of the screen
                 spawnPos = new Vector3(-offScreenSpawnPosition, 0, Random.Range(0,spawnRangeZ));
                 spawnRot = Quaternion.Euler(0,90f,0);
                 break;
             }
             case 1:
             {
                 //This is when animals spawn from the right hand side of the screen
                 spawnPos = new Vector3(offScreenSpawnPosition, 0, Random.Range(0,spawnRangeZ));
                 spawnRot = Quaternion.Euler(0,270f,0);
                 break;
             }
             case 2:
             {
                 //This is when animals spawn from the top of the screen
                 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX), 0, offScreenSpawnPosition);
                 spawnRot = Quaternion.Euler(0,180f,0);
                 break;
             }
         }
       
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, spawnRot);
    }
}
