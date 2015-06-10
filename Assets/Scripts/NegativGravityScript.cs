using UnityEngine;
using System.Collections;

public class NegativGravityScript : MonoBehaviour {

    Rigidbody rigidbodyComp;

	// Use this for initialization
	void Start () {
        rigidbodyComp = this.GetComponent<Rigidbody>();
        rigidbodyComp.useGravity = false;
	}

    void FixedUpdate()
    {
        rigidbodyComp.AddForce(-Physics.gravity, ForceMode.Acceleration);
    }
        
}
