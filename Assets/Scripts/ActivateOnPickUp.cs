using UnityEngine;
using System.Collections;

public class ActivateOnPickUp : MonoBehaviour {

    Rigidbody RigidbodyComp;

	// Use this for initialization
    void Awake()
    {
        RigidbodyComp = this.gameObject.GetComponent<Rigidbody>();
        RigidbodyComp.isKinematic = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void PickedUp()
    {
        RigidbodyComp.isKinematic = false;
    }
}
