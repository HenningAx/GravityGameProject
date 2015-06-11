/* 
This script is used to activate Rigidbodies only if the player is near.
This is used to improve performence and prevent changes in the level when the player is far away
*/




using UnityEngine;
using System.Collections;

public class ActivateIfPlayerIsNear : MonoBehaviour {

	void Start () {
        //Check if the object has a rigidbody and set to be kinematic
        Rigidbody rb = this.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        //If the object enters a RigidbodyActivator trigger it is set to not be kinematic
        if (other.tag == "RBActivator")
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.isKinematic = false;
                Debug.Log("Active");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        //If the object exits a RigidbodyActivator trigger it is set to kinematic
        if (other.tag == "RBActivator")
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }
}
