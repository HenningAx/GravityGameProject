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
