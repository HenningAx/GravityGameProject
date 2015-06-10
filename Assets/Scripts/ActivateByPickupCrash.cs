/*
 * This script is used to activate Rigidbodyies when a Pickup is colliding with them
 * the object will only be activated if the Pickup has enough velocity 
 */

using UnityEngine;
using System.Collections;

public class ActivateByPickupCrash : MonoBehaviour {

    public float FactivateThreshold = 10.0f;
    Rigidbody RigidbodyComp;

	// Use this for initialization
	void Awake () {
        //Get the Rigidbody Component and set it to kinematic
       RigidbodyComp = this.gameObject.GetComponent<Rigidbody>();
       RigidbodyComp.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        //if the object is collding with a pick up, which has enough velocity and isn't hold by the player, the Rigidbody is set to not be kinematic anymore
        if(col.collider.tag == "PickUp" && col.relativeVelocity.magnitude > FactivateThreshold && RigidbodyComp.isKinematic && col.collider.GetComponent<Rigidbody>().useGravity)
        {
            RigidbodyComp.isKinematic = false;
            RigidbodyComp.velocity = col.relativeVelocity;
        }
    }
}
