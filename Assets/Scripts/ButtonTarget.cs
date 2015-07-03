using UnityEngine;
using System.Collections;

public class ButtonTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	

    public virtual void TargetActivate()
    {
        Debug.Log(this.name + " activated");
    }

    public virtual void TargetDeactivate()
    {
        Debug.Log(this.name + " deactivated");
    }
}
