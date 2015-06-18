using UnityEngine;
using System.Collections;

public class FallingObjectsAudioControll : MonoBehaviour
{


    public AudioClip[] OnStone;
    public AudioClip[] OnMetal;
    public AudioClip[] OnWood;

	private float volumMult;


    private AudioSource FallingSound;
    

    private Rigidbody rb;

    
    



    void Awake()
    {
        FallingSound = this.GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody>();
    }



 

    void OnCollisionEnter(Collision col)
    {
		if (rb.useGravity && !(col.collider.tag == "Player")) {
			volumMult = col.relativeVelocity.magnitude / 15;
            
			int materialIndex = 0;
				
			//Check what the Surface hit is made of
			/*print ("Index " + materialIndex);
			if (col.gameObject.GetComponentInParent<MeshRenderer> ().materials [materialIndex].name.Contains ("_Stone")) { 
				PlaySound (OnStone);
				materialIndex = 0;

			} else if (col.gameObject.GetComponentInParent<MeshRenderer> ().materials [materialIndex].name.Contains ("_Metal")) {
				PlaySound (OnMetal);
				materialIndex = 0;
			} else if (col.gameObject.GetComponentInParent<MeshRenderer> ().materials [materialIndex].name.Contains ("_Wood")) {
				PlaySound (OnWood);
				materialIndex = 0;
			} */

			PlaySound (OnStone);
		}

	}



    

    void PlaySound(AudioClip[] clips)
    {


        int clipNum = Random.Range(0, clips.Length);
        FallingSound.clip = clips[clipNum];
        FallingSound.Play();
        FallingSound.volume = volumMult;
        print("play");
    }

    

}


    
