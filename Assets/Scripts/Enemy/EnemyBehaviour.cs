using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Camera cam;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private float swipeDistanceMin = 200f;
    private float dragDistanceMin = 300f;

    public float beatTempo;
    private float currentBeat;
    public int damagePoints;
    public bool canBeKilled, canBeDraged, canBeSwiped, isKilled, DragedSate;
    public bool isStandard;

    public enum EnemyClass {Standard, Swipe, Drag};
    public EnemyClass enemyClass;

    private RaycastHit mousePosition;

    float distanceForDragEnemy, numberOfStripePassed;

	// Use this for initialization
	void Start ()
    {
        cam = Camera.main;
        beatTempo = GameObject.FindGameObjectWithTag("FretteParent").GetComponent<StripeBumping>().beatTempo;
        currentBeat = beatTempo / 60f;
        if (enemyClass == EnemyClass.Swipe)
        {
            isStandard = false;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Enemy movement
        transform.position -= new Vector3(0f, 0f, currentBeat * Time.deltaTime);

        if (Input.touchCount == 1)
        {
            var touch = Input.touches[0];
            if (enemyClass == EnemyClass.Swipe)
            {
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
            if(enemyClass == EnemyClass.Drag && numberOfStripePassed > 1 && !DragedSate)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        // Stockage du point de départ
                        startPosition = touch.position;
                        //transform.position = mousePosition.transform.position;
                        break;
                    case TouchPhase.Ended:
                        // Stockage du point de fin
                        endPosition = touch.position;
                        AnalyzeGesture(startPosition, endPosition);
                        break;
                }
            }
        }
    }

    private void AnalyzeGesture(Vector2 start, Vector2 end)
    {
        //Debug.Log(Mathf.Abs(end.x - start.x));
        // Distance
        if (Vector2.Distance(start, end) > swipeDistanceMin)
        {
            if (enemyClass == EnemyClass.Swipe && !isStandard)
            {
                isStandard = true;
            }
        }
        
        //if (Mathf.Abs(end.x - start.x) > dragDistanceMin || Mathf.Abs(end.y - start.y) > dragDistanceMin)
        if (Mathf.Abs(end.x - start.x) < Mathf.Abs(end.y - start.y))
        {
            if (end.y - start.y > 0)
            {
                {
                    if (enemyClass == EnemyClass.Drag)
                    {
                        DragEnemyMovement();
                    }
                }
            }
        }
        
    }

    public void DragEnemyMovement()
    {
        currentBeat *= -2;
        numberOfStripePassed = 0;
        DragedSate = true;
    }

    void RestoreEnemyMovement()
    {
        currentBeat = beatTempo / 60f;
        DragedSate = false;
        canBeKilled = false;
        numberOfStripePassed = 0;
    }

    private void OnMouseDrag()
    {
        /*
        if (enemyClass == EnemyClass.Drag && canBeDraged)
        {
            currentBeat = 0f;
            Vector3 point = Camera.main.ScreenToWorldPoint(
                    new Vector3(
                        (transform.position.x - Camera.main.transform.position.x),
                        Input.mousePosition.y,
                        (transform.position.z - Camera.main.transform.position.z)));

            point.x = transform.position.x;
            point.y = transform.position.z;
            transform.position = point;
            Vector3.ProjectOnPlane(point, GameObject.FindGameObjectWithTag("Ground").GetComponent<Transform>().position);
            //transform.position = point;
        }
        */
    }

    /*
    private void OnMouseUp()
    {
        if (enemyClass == EnemyClass.Drag)
        {
            if (canBeKilled)
            {
                Destroy(gameObject);
            }
            else
            {
                currentBeat = beatTempo / 60f;
            }
        }
    }
    */

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

                    break;
                case EnemyClass.Drag:
                    canBeDraged = true;
                    if(numberOfStripePassed > 2)
                    {
                        canBeKilled = true;
                    }
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
            switch (enemyClass)
            {
                case EnemyClass.Standard:
                    canBeKilled = false;
                    break;
                case EnemyClass.Drag:
                    canBeDraged = false;
                    numberOfStripePassed++;
                    Debug.Log(numberOfStripePassed);
                    if (numberOfStripePassed > 1 && DragedSate)
                    {
                        RestoreEnemyMovement();
                    }
                    break;
                case EnemyClass.Swipe:
                    if (isStandard)
                    {
                        enemyClass = EnemyClass.Standard;
                    }
                    break;
            }
        }
    }
}
