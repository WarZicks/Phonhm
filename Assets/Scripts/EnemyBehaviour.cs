using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float beatTempo;
    private float currentBeat;
    public int damagePoints;

    public bool hasStarted;

	// Use this for initialization
	void Start ()
    {
        currentBeat = beatTempo / 60f;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!hasStarted)
        {
            if(Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, currentBeat * Time.deltaTime, 0f);
        }
	}
}
