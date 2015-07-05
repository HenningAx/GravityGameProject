﻿//Activates a rigidbody if the script receives an activate input from a button


using UnityEngine;
using System.Collections;

public class UnlockDoorButtonScript : ButtonTarget {


    Rigidbody rbComp;

	// Use this for initialization
	void Start () {
        rbComp = this.GetComponent<Rigidbody>();
        rbComp.isKinematic = true;

	}

    public override void TargetActivate()
    {
        base.TargetActivate();
        rbComp.isKinematic = false;

        
    }
	
}
