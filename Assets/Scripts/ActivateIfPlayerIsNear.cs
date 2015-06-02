using UnityEngine;
using System.Collections;

public class ActivateIfPlayerIsNear : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
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
