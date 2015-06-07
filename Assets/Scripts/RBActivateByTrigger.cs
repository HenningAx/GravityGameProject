using UnityEngine;
using System.Collections;

public class RBActivateByTrigger : MonoBehaviour {

    Rigidbody RBComp;

	// Use this for initialization
	void Start () {
        RBComp = this.GetComponent<Rigidbody>();
        RBComp.isKinematic = true;
	
	}

    void Activate()
    {
        RBComp.isKinematic = false;
    }
}
