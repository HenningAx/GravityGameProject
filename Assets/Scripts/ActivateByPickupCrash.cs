using UnityEngine;
using System.Collections;

public class ActivateByPickupCrash : MonoBehaviour {

    public float FactivateThreshold = 10.0f;
    Rigidbody RigidbodyComp;

	// Use this for initialization
	void Awake () {
       RigidbodyComp = this.gameObject.GetComponent<Rigidbody>();
       RigidbodyComp.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "PickUp" && col.relativeVelocity.magnitude > FactivateThreshold && RigidbodyComp.isKinematic && col.collider.GetComponent<Rigidbody>().useGravity)
        {
            RigidbodyComp.isKinematic = false;
            RigidbodyComp.velocity = col.relativeVelocity;
        }
    }
}
