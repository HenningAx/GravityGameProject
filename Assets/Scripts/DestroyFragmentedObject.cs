using UnityEngine;
using System.Collections;

public class DestroyFragmentedObject : MonoBehaviour {

    public GameObject Gfragments;
    public float FdestroyThreshold = 10;
    public float FexplodeRadius = 3.0f;
    public float FexplodePower = 3.0f;
    public float FfragsFadeOutTimeMax = 10.0f;
    public float FfragsFadeOutDelayMax = 10.0f;

    FadeScript[] fadeScriptComps;

	// Use this for initialization
	void Start () {
        fadeScriptComps = GetComponentsInChildren<FadeScript>();
        print(fadeScriptComps.Length);
        Gfragments.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(Collision col)
    {
        if (this.GetComponent<Rigidbody>() != null)
        {
            if (col.relativeVelocity.magnitude * Vector3.Dot(col.contacts[0].normal.normalized, col.relativeVelocity.normalized) > FdestroyThreshold && this.GetComponent<Rigidbody>().useGravity && col.collider.tag != "Player" && col.collider.tag != "Frags")
            {

                Gfragments.SetActive(true);
                //this.BroadcastMessage("FadeOut", SendMessageOptions.DontRequireReceiver);
                foreach(FadeScript fs in fadeScriptComps)
                {
                    fs.FadeOut(Random.Range(0, FfragsFadeOutTimeMax), Random.Range(0, FfragsFadeOutDelayMax));
                }
                transform.DetachChildren();
                PhysicFunctions.ExplodeOnImpact(this.transform.position, FexplodeRadius, FexplodePower, this.GetComponent<Rigidbody>().velocity);       
                Destroy(this.gameObject); 
            }
        } else
        {
            if (col.relativeVelocity.magnitude * Vector3.Dot(col.contacts[0].normal.normalized, col.relativeVelocity.normalized) > FdestroyThreshold && col.collider.tag != "Player" && col.collider.tag != "Frags")
            {
                Gfragments.SetActive(true);
                //this.BroadcastMessage("FadeOut", SendMessageOptions.DontRequireReceiver);
                foreach (FadeScript fs in fadeScriptComps)
                {
                    fs.FadeOut(Random.Range(0, FfragsFadeOutTimeMax), Random.Range(0, FfragsFadeOutDelayMax));
                }
                transform.DetachChildren();
                PhysicFunctions.ExplodeOnImpact(this.transform.position, FexplodeRadius, FexplodePower);
            }
        }
    }
}
