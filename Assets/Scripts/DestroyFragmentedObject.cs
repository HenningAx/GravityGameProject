using UnityEngine;
using System.Collections;

public class DestroyFragmentedObject : MonoBehaviour {

    public GameObject Gfragments;
    public float FdestroyThreshold = 10;
    public float FexplodeRadius = 3.0f;
    public float FexplodePower = 3.0f;

	// Use this for initialization
	void Start () {
        Gfragments.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.relativeVelocity.magnitude > FdestroyThreshold && this.GetComponent<Rigidbody>().useGravity)
        {
            
            Gfragments.SetActive(true);
            this.BroadcastMessage("FadeOut");
            transform.DetachChildren();
            PhysicFunctions.ExplodeOnImpact(this.transform.position, FexplodeRadius, FexplodePower);
            Destroy(this.gameObject);
        }
    }
}
