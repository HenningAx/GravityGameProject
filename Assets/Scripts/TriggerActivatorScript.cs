//Activates the targets when the player enters the trigger


using UnityEngine;
using System.Collections;

public class TriggerActivatorScript : MonoBehaviour {

    public GameObject[] Targets;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            foreach(GameObject Target in Targets)
            {
                Target.SendMessage("Activate");
                Destroy(this);
            }
        }
    }
}
