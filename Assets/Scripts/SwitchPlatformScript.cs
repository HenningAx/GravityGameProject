/* This script should be attached to a switch platform
 * when the player enters the platform the FlipGravity function is called
 * */

using UnityEngine;
using System.Collections;

public class SwitchPlatformScript : MonoBehaviour {
    Vector3 VownGravity;
    Rigidbody RBcomp;
    bool BpickedUp = false;

	// Use this for initialization
	void Start () {
        VownGravity = Physics.gravity;
        RBcomp = this.GetComponent<Rigidbody>();
        RBcomp.useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {
        //If the platform is not picked up, apply her own gravity
        if (!BpickedUp)
        {
            RBcomp.AddForce(VownGravity, ForceMode.Acceleration);
        }
	
	}

    void OnTriggerEnter(Collider other)
    {
        //Check if the Trigger is a platform to change gravity
        if (other.tag == "Player")
        {
            if (!BpickedUp)
            {
                other.gameObject.SendMessage("FlipGravity", other);
            }
        }
    } 

    void PickedUp()
    {
        BpickedUp = true;
    }

    void Droped()
    {
        BpickedUp = false;
        VownGravity = Physics.gravity;
        RBcomp.useGravity = false;
    }



}
