using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;

    public GameObject playerPrefab;

    public int score;

    public float spawnDistance;

    public List<GameObject> enemyList;

    public List<GameObject> enemyPrefabList;

    public List<Transform> spawnPointList;

    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            enemyList = new List<GameObject>();
        }
        else
        {
            Destroy(this.gameObject);
            Debug.LogError("[Game manager attempted to make a second game manager: ]" + this.gameObject.name);
        }
    }
    private void Start()
    {
        SpawnPlayer();
    }
    private void SpawnEnemy()
    {
        //pick a random enemy to spawn
        GameObject enemyToSpawn = enemyPrefabList[Random.Range(0, enemyPrefabList.Count)];

        //pick a random spawn point

       Transform spawnPoint= spawnPointList[Random.Range(0, spawnPointList.Count)];
        //pick a point within the distance of the spawn point randomly
        Vector3 randomVector = Random.insideUnitCircle;
        Vector3 newPosition = spawnPoint.position + (randomVector * spawnDistance);
        //instantiate the selected enemy at the selected position.
        Instantiate(enemyToSpawn, newPosition,Quaternion.identity);
    }
    private void Update()
    {
        if (player != null)
        {
             if (enemyList.Count < 3)
            {
            SpawnEnemy();
             }
        }
        else
        {
            DestoyAllEnemies();
            
        }
        //spawn a new enemy if enemies is less than 3
       

    
  
    }
    private void SpawnPlayer()
    {
        if (player != null)
        {
            player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }
    }
    public void DestoyAllEnemies()
    {
        foreach(GameObject enemy in enemyList)
        {
            Destroy(enemy);
        }
    }
}
  
