using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Singleton;

    private void Awake()
    {
        if (Singleton != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Singleton = this;
        }
    }
    #endregion
    public float scoreFinal = 0f;
    public int combo = 1;
    public float enemyPoints = 100f;
    public float pointsToAdd;

    private bool canSpawn0 = true, canSpawn1 = true, canSpawn2 = true;
    private GameObject enemySpawned0, enemySpawned1, enemySpawned2;
    public GameObject Spawner0, Spawner1, Spawner2;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (canSpawn0)
        {
            Spawner0.GetComponent<EnemySpawner>().ChooseEnemyToSpawn();
        }
        
        if (canSpawn1)
        {
            Spawner1.GetComponent<EnemySpawner>().ChooseEnemyToSpawn();
        }
        
        if (canSpawn2)
        {
            Spawner2.GetComponent<EnemySpawner>().ChooseEnemyToSpawn();
        }
        
    }

    public void EarnPoints ()
    {
            pointsToAdd = enemyPoints * combo;
            scoreFinal += pointsToAdd;
            combo += 1;
            Debug.Log(scoreFinal);
    }

    public void BreakCombo ()
    {
            combo = 1;
            pointsToAdd = enemyPoints * combo;
            Debug.Log("Combo Cassé");
    }
}
