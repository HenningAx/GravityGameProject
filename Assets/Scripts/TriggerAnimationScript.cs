//Sets the trigger on the target Animator to a given value if the player enters the trigger

using UnityEngine;
using System.Collections;

public class TriggerAnimationScript : MonoBehaviour {

    public Animator aniTarget;
    public string animationTrigger;

   void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
       {
           aniTarget.SetTrigger(animationTrigger);
           Destroy(this);
       }
    }
}
