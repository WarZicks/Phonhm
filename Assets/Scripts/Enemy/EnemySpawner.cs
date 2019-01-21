using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject EnemyPawn;

	// Use this for initialization
	void Start () {
        SpawnAnEnemy();
	}
	
	// Update is called once per frame
	void Update () {
           
        }

    public void SpawnAnEnemy()
    {
        Instantiate(EnemyPawn, transform.position, Quaternion.identity);
    }
}
