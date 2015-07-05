//Event script for the elvator crash


using UnityEngine;
using System.Collections;

public class ElevatorCrash : MonoBehaviour {
    public float BexplosionRadius = 5.0f;
    public float BexplosionForce = 50.0f;
    public AudioSource crashSound;

    bool BisCrashed = false;
    bool BplayerInside = false;

	// Use this for initialization
	void Start () {
	
	}
	
    void OnCollisionEnter(Collision col)
    {
        //Kill the player and add an explosion force to surronding rigidbodies
        if(col.collider.tag == "DamagePlayer" && !BisCrashed && BplayerInside)
        {
            crashSound.Play();
            BisCrashed = true;
            Camera.main.GetComponentInParent<HealthSystem>().TakeDamage(100f);
            PhysicFunctions.ExplodeOnImpact(col.contacts[0].point, BexplosionRadius, BexplosionForce);
        }
    }


    //Set the playerInside variable to only be true if the player is inside the elevator
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            BplayerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "player")
        {
            BplayerInside = false;
        }
    }
}
