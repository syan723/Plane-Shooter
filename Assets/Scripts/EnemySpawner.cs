using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public float respawnTime = 2f;
    public int enemySpawnCount = 10;
   public GameController gameController;
    private bool lastEnemySpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
       //SpawnEnemies();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(lastEnemySpawned && FindObjectOfType<EnemyAirCraft>() == null)
        {
            StartCoroutine(gameController.LevelComplete());
        } 
    }
    IEnumerator Spawner()
    {
        for (int i = 0; i < enemySpawnCount; i++)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemies();
        }
        lastEnemySpawned=true;

    }
    void SpawnEnemies()
    {
        int randomValueOfEnemies = Random.Range(0, enemy.Length);
        float randomXpos = Random.Range(-2.5f, 2.5f);
        Instantiate(enemy[randomValueOfEnemies], new Vector3(randomXpos,transform.position.y,-1.5f),Quaternion.identity);
      
    }
}
