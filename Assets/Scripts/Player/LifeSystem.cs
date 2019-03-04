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

    public GameObject[] Light_Bafle;
    private Material M_Bafle;
    public Material[] M_Light;
    

	// Use this for initialization
	void Start ()
    {
        _AudioSource = GetComponent<AudioSource>();
        //M_Bafle = Obj_Bafle.GetComponent<MeshRenderer>().materials.;
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
        ChangeBafleLightColor();
        PlayerDead();
    }

    void ChangeBafleLightColor()
    {
        switch (healthPoints)
        {
            case 2:
                Light_Bafle[0].SetActive(false);
                Light_Bafle[1].SetActive(true);
                Light_Bafle[2].SetActive(false);
                break;

            case 1:
                Light_Bafle[0].SetActive(false);
                Light_Bafle[1].SetActive(false);
                Light_Bafle[2].SetActive(true);
                break;

        }
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
