using UnityEngine;
using System.Collections;

public class TestContraints : MonoBehaviour {
    Rigidbody RBcomp;

	// Use this for initialization
	void Start () {
        RBcomp = GetComponent<Rigidbody>();
        Debug.Log(RBcomp.constraints);
        switch (RBcomp.constraints)
        {
            case (RigidbodyConstraints) 12:
                print("FreeX");
                break;
            case (RigidbodyConstraints) 10:
                print("FreeY");
                break;
            case (RigidbodyConstraints) 6:
                print("FreeZ");
                break;
        }


            

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
