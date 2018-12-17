using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float beatTempo;
    private float currentBeat;
    public int damagePoints;
    public bool canBeKilled;

	// Use this for initialization
	void Start ()
    {
        currentBeat = beatTempo / 60f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position -= new Vector3(0f, 0f, currentBeat * Time.deltaTime);
	}
    

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("TriggerStripe"))
        {
            canBeKilled = true;
            Debug.Log("can be killed");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerStripe"))
        {
            canBeKilled = false;
        }
    }
}
