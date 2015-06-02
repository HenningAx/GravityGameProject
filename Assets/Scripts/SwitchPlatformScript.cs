using UnityEngine;
using System.Collections;

public class SwitchPlatformScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //Check if the Trigger is a platform to change gravity
        if (other.tag == "Player")
        {
            other.gameObject.SendMessage("FlipGravity", other);
        }
    } 

}
