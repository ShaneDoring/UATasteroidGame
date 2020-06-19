using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;

    public int score;

    public List<GameObject> enemyList;

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
 
}
  
