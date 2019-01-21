using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StripeBumping : MonoBehaviour {

    public float beatTempo;
    public float Impulse;
    Rigidbody m_Rigidbody;
    private float _beatInterval, _beatTimer;
    private bool _beatFull, isGrounded = true;
    private AudioSource m_AudioSource;


    // Use this for initialization
    void Start () {
        //beatTempo = beatTempo/ 60;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        BeatDetection();
	}

    void BeatDetection()
    {
        // Full beat count
        _beatFull = false;
        _beatInterval = 60 / beatTempo;
        _beatTimer += Time.deltaTime;
        if (_beatTimer >= _beatInterval)
        {
            _beatTimer -= _beatInterval;
            _beatFull = true;
            Bumping();
        }
    }

    void Bumping()
    {
        if (isGrounded)
        {
            m_Rigidbody.AddForce(Vector3.up * Impulse, ForceMode.Impulse);
            m_AudioSource.Play();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
