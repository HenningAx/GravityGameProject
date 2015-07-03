using UnityEngine;
using System.Collections;

public class ButtonDoorOpen : ButtonTarget {

    Rigidbody rbComp;
	void Start () {
        rbComp = GetComponent<Rigidbody>();
        rbComp.isKinematic = true;
	}

    public override void TargetActivate()
    {
        base.TargetActivate();
        rbComp.isKinematic = false;
    }
}
