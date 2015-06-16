using UnityEngine;
using System.Collections;

public class FallingObjectsAudioControll: MonoBehaviour {


	public GameObject GoFallingOnStone;
	public GameObject GoFallingOnWood;
	public GameObject GoFallingOnMetal;

    private AudioSource FallingOnStone;
	private AudioSource FallingOnWood;
	private AudioSource FallingOnMetal;
   
	public int clipNum;
    private float volumMult;
   

    void Awake()
    {
		FallingOnStone = GoFallingOnStone.GetComponent<AudioSource> ();

    }
	        
       
     
    
    void OnCollisionEnter(Collision col)
    {

		//Check if the Surface hit is made of stone and randomly set audio clip
        //if (col.gameObject.GetComponent<MeshRenderer>().material.name.Contains "_Stone")
        if(col.gameObject.tag == "Wand" )
        {
            volumMult = col.relativeVelocity.magnitude * 1/20;

			clipNum = Random.Range (0,GoFallingOnStone.GetComponent<AudioClipAssigner>().AudioClips.Length);

			FallingOnStone.Play();
			FallingOnStone.volume = volumMult;
			print (clipNum);
            
        }

    }
}
