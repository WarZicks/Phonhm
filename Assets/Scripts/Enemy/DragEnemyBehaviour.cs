using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragEnemyBehaviour : MonoBehaviour {

    float distance = 10;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    private void OnMouseDrag()
    {
        /*
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);    

        transform.position = objPosition;
        */
        Vector3 point = Camera.main.ScreenToWorldPoint(
                new Vector3(
                    Input.mousePosition.x,
                    (transform.position.y - Camera.main.transform.position.y),
                    (transform.position.z - Camera.main.transform.position.z)));

        point.y = transform.position.y;
        point.z = transform.position.z;
        transform.position = point;
    }
}
