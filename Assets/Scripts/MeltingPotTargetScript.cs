using UnityEngine;
using System.Collections;

public class MeltingPotTargetScript : ButtonTarget {

    Rigidbody rbComp;

	// Use this for initialization
	void Start () {
        rbComp = this.GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void TargetActivate()
    {
        base.TargetActivate();
        rbComp.isKinematic = false;
    }
}
