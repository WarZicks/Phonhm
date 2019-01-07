using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 endPosition;
    private float swipeDistanceThreshold = 50;

    public float beatTempo;
    private float currentBeat;
    public int damagePoints;
    public bool canBeKilled, canBeDraged, canBeSwiped;

    public enum EnemyClass {Standard, Swipe, Drag};
    private EnemyClass enemyClass;

	// Use this for initialization
	void Start ()
    {
        currentBeat = beatTempo / 60f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Enemy movement
        transform.position -= new Vector3(0f, 0f, currentBeat * Time.deltaTime);

        if (Input.touchCount == 1)
        {
            var touch = Input.touches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Stockage du point de départ
                    startPosition = touch.position;
                    break;
                case TouchPhase.Ended:
                    // Stockage du point de fin
                    endPosition = touch.position;
                    AnalyzeGesture(startPosition, endPosition);
                    break;
            }
        }
    }

    private void AnalyzeGesture(Vector2 start, Vector2 end)
    {
        // Distance
        if (Vector2.Distance(start, end) > swipeDistanceThreshold)
        {
            enemyClass = EnemyClass.Standard;
        }
    }

    // Deal damage to player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<LifeSystem>().DoDamage();
            Destroy(gameObject);
        }
    }

    // Kill enemy with click
    private void OnMouseDown() 
    {
        if (canBeKilled)
        {
            Debug.Log("Click");
            Destroy(gameObject);
        }
    }

    // Trigger with stripes enter
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("TriggerStripe"))
        {
            switch(enemyClass)
            {
                case EnemyClass.Standard:
                    canBeKilled = true;
                    Debug.Log("can be killed");
                    break;
                case EnemyClass.Drag:
                    canBeDraged = true;
                    break;
                case EnemyClass.Swipe:
                    canBeSwiped = true;
                    break;
            }
        }
    }

    // Trigger with stripes exit
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerStripe"))
        {
            canBeKilled = false;
        }
    }
}
