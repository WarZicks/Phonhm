using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragEnemyBehaviour : MonoBehaviour {

    float distance = 10;

    public float beatTempo;
    private float currentBeat;

    // Use this for initialization
    void Start () {
        beatTempo = GameObject.FindGameObjectWithTag("FretteParent").GetComponent<StripeBumping>().beatTempo;
        currentBeat = beatTempo / 60f;
    }
	
	// Update is called once per frame
	void Update () {
        // Enemy movement
        transform.position -= new Vector3(0f, 0f, currentBeat * Time.deltaTime);
    }

    private void OnMouseDrag()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(
                new Vector3(
                    Input.mousePosition.x,
                    (transform.position.y - Camera.main.transform.position.y),
                    (transform.position.z - Camera.main.transform.position.z)));

        point.y = transform.position.y;
        point.z = transform.position.z;
        transform.position = point;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<LifeSystem>().DoDamage();
            Destroy(gameObject);
        }
    }
}
