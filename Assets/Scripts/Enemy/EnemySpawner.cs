using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Normal
    public float maxTimeEnemyNormal = 5;
    public float minTimeEnemyNormal = 2;
    private float spawnTimeEnemyNormal;
    private float timeEnemyNormal;
    public GameObject EnemyPawnNormal;
    // Swipe
    public float maxTimeEnemySwipe = 7;
    public float minTimeEnemySwipe = 3;
    private float spawnTimeEnemySwipe;
    private float timeEnemySwipe;
    public GameObject EnemyPawnSwipe;
    // Drag
    public float maxTimeEnemyDrag = 9;
    public float minTimeEnemyDrag = 5;
    private float spawnTimeEnemyDrag;
    private float timeEnemyDrag;
    public GameObject EnemyPawnDrag;
    
    
    // Use this for initialization
    void Start ()
    {
        SetRandomTimeNormal();
        SetRandomTimeSwipe();
        SetRandomTimeDrag();
        timeEnemyNormal = minTimeEnemyNormal;
        timeEnemySwipe = minTimeEnemySwipe;
        timeEnemyDrag = minTimeEnemyDrag;
    }

    void FixedUpdate()
    {
        timeEnemyNormal += Time.deltaTime;
        timeEnemySwipe += Time.deltaTime;
        timeEnemyDrag += Time.deltaTime;
    }

    // Update is called once per frame
    void Update ()
    {
           
    }

    void SetRandomTimeNormal()
    {
        spawnTimeEnemyNormal = Random.Range(minTimeEnemyNormal, maxTimeEnemyNormal);
    }

    void SetRandomTimeSwipe()
    {
        spawnTimeEnemySwipe = Random.Range(minTimeEnemySwipe, maxTimeEnemySwipe);
    }

    void SetRandomTimeDrag()
    {
        spawnTimeEnemyDrag = Random.Range(minTimeEnemyDrag, maxTimeEnemyDrag);
    }


    public void ChooseEnemyToSpawn()
    {
        // Normal
        if (timeEnemyNormal >= spawnTimeEnemyNormal)
        {
            SpawnObjectNormal();
            SetRandomTimeNormal();
            timeEnemySwipe -= 1f;
            timeEnemyDrag -= 1f;
        }
        // Swipe
        else if (timeEnemySwipe >= spawnTimeEnemySwipe)
        {
            SpawnObjectSwipe();
            SetRandomTimeSwipe();
            timeEnemyNormal -= 1f;
            timeEnemyDrag -= 1f;
        }
        // Drag
        else if (timeEnemyDrag >= spawnTimeEnemyDrag)
        {
            SpawnObjectDrag();
            SetRandomTimeDrag();
            timeEnemyNormal -= 1f;
            timeEnemySwipe -= 1f;
        }
    }

    void SpawnObjectNormal()
    {
            timeEnemyNormal = 0f;
            Instantiate(EnemyPawnNormal, transform.position, Quaternion.identity);
    }

    void SpawnObjectSwipe()
    {
            timeEnemySwipe = 0f;
            Instantiate(EnemyPawnSwipe, transform.position, Quaternion.identity);
    }


    void SpawnObjectDrag()
    {
            timeEnemyDrag = 0f;
            Instantiate(EnemyPawnDrag, transform.position, Quaternion.identity);
    }
    
}
