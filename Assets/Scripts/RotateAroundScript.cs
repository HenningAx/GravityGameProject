//A script just to test Unity's RotateAround function

using UnityEngine;
using System.Collections;

public class RotateAroundScript : MonoBehaviour {

    MeshRenderer MeshComp;
    Vector3 LowestPoint;

	// Use this for initialization
	void Start () {
        MeshComp = gameObject.GetComponent<MeshRenderer>();
        LowestPoint = transform.position - Vector3.up * (MeshComp.bounds.size.y / 2);
	
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.RotateAround(LowestPoint, transform.right, 50 * Time.deltaTime);
	
	}
}
