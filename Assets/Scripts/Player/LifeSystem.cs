using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public int healthPoints;
    public bool isDead;
    private AudioSource _AudioSource;
    public AudioClip Snd_TakeDamage;
    public AudioClip Snd_GameOver;

	// Use this for initialization
	void Start ()
    {
        _AudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void DoDamage ()
    {
        healthPoints -= GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyBehaviour>().damagePoints;
        _AudioSource.clip = Snd_TakeDamage;
        _AudioSource.Play();
        if (healthPoints >= 1)
        {
            Debug.Log("Player HP = " + healthPoints);
        }
        PlayerDead();
    }

    public void PlayerDead ()
    {
        if (healthPoints <= 0)
        {
            _AudioSource.clip = Snd_GameOver;
            _AudioSource.Play();
            isDead = true;
            Debug.Log("Dead");
            Time.timeScale = 0f;
            GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().ActivateDeadMenu();
        }
    }
}
