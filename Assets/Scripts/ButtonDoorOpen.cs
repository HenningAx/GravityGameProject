//A ButtonTarget script for activating rigidbodys

using UnityEngine;
using System.Collections;

public class ButtonDoorOpen : ButtonTarget {

    Rigidbody rbComp;
	void Start () {
        //Get the rigidbody comp and set it to kinematic
        rbComp = GetComponent<Rigidbody>();
        rbComp.isKinematic = true;
	}

    public override void TargetActivate()
    {
        base.TargetActivate();
        rbComp.isKinematic = false;
    }
}
