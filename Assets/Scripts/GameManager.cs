using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float scoreFinal = 0f;
    public int combo = 1;
    public float enemyPoints = 100f;
    public float pointsToAdd;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void EarnPoints ()
    {
        if (Input.GetKeyDown("f"))
        {
            pointsToAdd = enemyPoints * combo;
            scoreFinal += pointsToAdd;
            combo += 1;
            Debug.Log(scoreFinal);
        }
    }

    public void BreakCombo ()
    {
        if (Input.GetKeyDown("g"))
        {
            combo = 1;
            pointsToAdd = enemyPoints * combo;
            Debug.Log("Combo Cassé");
        }
    }
}
