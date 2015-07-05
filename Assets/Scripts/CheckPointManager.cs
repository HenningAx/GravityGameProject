/* This script is used for setting checkpoints and resetting the player to them
 * a initial checkpoint has to be assigned */

using UnityEngine;
using System.Collections;

public class CheckPointManager : MonoBehaviour {

    public GameObject InitialCheckpoint;
    Vector3 VstdGravity;
    Vector3 VactiveCheckpoint;
    RaycastHit ground;
    public GameObject Target;
    GravityChanger changerScript;

    void Awake()
    {
        VactiveCheckpoint = InitialCheckpoint.transform.position;
        Physics.Raycast(VactiveCheckpoint, Physics.gravity, out ground);
        VstdGravity = Physics.gravity;
        changerScript = Target.GetComponent<GravityChanger>();
    }

    //Set a new Checkpoint
    public void setCheckpoint(Vector3 newCheckpoint, RaycastHit gd)
    {
        VactiveCheckpoint = newCheckpoint;
        ground = gd;
    }

    //Reset the player to the last Checkpoint
    public void resetToCheckpoint()
    {
        Target.transform.position = VactiveCheckpoint;
        changerScript.StartWalkingOnWall(ground);
    }
}
