/* This script is used to destroy a prefragmented object on collision and fade them out to prevent performence drops from having to many Rigidbodies
 * the fragments of the object have to be childs of the original object this script is attached to
 * for fading out all fragments must have the FadeScript attached and the rendering mode of the material of the fragments has to be set to a transparent type
 * on collision the script will check if the force of the collision is higher then the destroyThreshold
 * if this is true the childs will be detached and the FadeOut Sequence on them is started
 * for a cooler look a explosion force from the pivot of the original object is applied to all Rigidbodies near to the destruction
 * the force of the explosion can be controlled over public variables
 */


using UnityEngine;
using System.Collections;

public class DestroyFragmentedObject : MonoBehaviour {

    public GameObject Gfragments;
    public float FdestroyThreshold = 10;
    public float FexplodeRadius = 3.0f;
    public float FexplodePower = 3.0f;
    public float FfragsFadeOutTimeMax = 10.0f;
    public float FfragsFadeOutDelayMax = 10.0f;

	private AudioSource source;


    

    FadeScript[] fadeScriptComps;

	void Start () {
        //Get all FadeScripts on the fragments to save performence on runtime
        fadeScriptComps = GetComponentsInChildren<FadeScript>();
        //Set the fragments to inactive, so they are not visible while the object isn't destroyed
        Gfragments.SetActive(false);
		source = Gfragments.GetComponent<AudioSource>();
	}
	
    void OnCollisionEnter(Collision col)
    {
        if (this.GetComponent<Rigidbody>() != null)
        {
            if (col.relativeVelocity.magnitude * Vector3.Dot(col.contacts[0].normal.normalized, col.relativeVelocity.normalized) > FdestroyThreshold && this.GetComponent<Rigidbody>().useGravity && col.collider.tag != "Player" && col.collider.tag != "Frags")
            {

                Gfragments.SetActive(true);
                if (source)
                {
                    source.Play();
                }
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
                foreach (FadeScript fs in fadeScriptComps)
                {
                    fs.FadeOut(Random.Range(0, FfragsFadeOutTimeMax), Random.Range(0, FfragsFadeOutDelayMax));
                }
                transform.DetachChildren();
                PhysicFunctions.ExplodeOnImpact(this.transform.position, FexplodeRadius, FexplodePower);
                Destroy(this.gameObject);

                
                
            }
        }
    }
}
