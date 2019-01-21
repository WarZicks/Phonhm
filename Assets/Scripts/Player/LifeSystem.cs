using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public int healthPoints;
    public bool isDead;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void DoDamage ()
    {
        healthPoints -= GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyBehaviour>().damagePoints;
        Debug.Log("Player HP = " + healthPoints);
        PlayerDead();
    }

    public void PlayerDead ()
    {
        if (healthPoints <= 0)
        {
            isDead = true;
            Debug.Log("Dead");
        }
    }
}
