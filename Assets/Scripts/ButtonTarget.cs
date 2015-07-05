/* The standard ButtonTarget script
 * the the function should be overriden by a script extending the ButtonTarget class */

using UnityEngine;
using System.Collections;

public class ButtonTarget : MonoBehaviour {


    public virtual void TargetActivate()
    {
        Debug.Log(this.name + " activated");
    }

    public virtual void TargetDeactivate()
    {
        Debug.Log(this.name + " deactivated");
    }
}
