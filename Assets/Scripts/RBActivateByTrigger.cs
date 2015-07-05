//This script activates the rigidbody this script is attached to when the Activate function is called

using UnityEngine;
using System.Collections;

public class RBActivateByTrigger : MonoBehaviour {

    Rigidbody RBComp;

	void Start () {
        RBComp = this.GetComponent<Rigidbody>();
        RBComp.isKinematic = true;
	
	}

    void Activate()
    {
        RBComp.isKinematic = false;
    }
}
