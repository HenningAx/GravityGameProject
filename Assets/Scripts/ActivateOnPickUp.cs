/*
 * This script is used to activate Rigidbodies when they are picked up by the player
 * the won't be disabled afterwards
 */

using UnityEngine;
using System.Collections;

public class ActivateOnPickUp : MonoBehaviour {

    Rigidbody RigidbodyComp;

    void Awake()
    {
        //Get the Rigidbody Component and set it to kinematic
        RigidbodyComp = this.gameObject.GetComponent<Rigidbody>();
        RigidbodyComp.isKinematic = true;
    }

    //On pick up the rigidbody is set to be not kinematic
    void PickedUp()
    {
        RigidbodyComp.isKinematic = false;
    }
}
