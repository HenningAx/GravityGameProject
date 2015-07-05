/* This script sets a new checkpoint
 * the script has to be attached to the checkpoint
 * the setCheckpoint function has to be called from outside for example by a trigger
 * a CheckPointManager need to be in the scene to capture the checkpoint
 * */

using UnityEngine;
using System.Collections;

public class SetCheckpoint : MonoBehaviour {
    public GameObject Checkpoint;
    CheckPointManager managerScript;
    RaycastHit Ground;

    void Awake()
    {
        managerScript = GameObject.Find("CheckPointManager").GetComponent<CheckPointManager>();
        Physics.Raycast(Checkpoint.transform.position, Physics.gravity, out Ground);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            setCheckpoint();
        }
    }

    public void setCheckpoint()
    {
        managerScript.setCheckpoint(Checkpoint.transform.position, Ground);
    }

}
