using UnityEngine;
using System.Collections;

public class CollisionTestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.collider.name);
    }
}
