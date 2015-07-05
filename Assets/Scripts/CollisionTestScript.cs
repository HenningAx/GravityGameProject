//Script for testing with which objects a the gameobject this script is attached to is colliding

using UnityEngine;
using System.Collections;

public class CollisionTestScript : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.collider.name);
    }
}
