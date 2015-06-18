using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class TransitionToSnaphotScript : MonoBehaviour {


	public AudioMixerSnapshot[] 	enteredArea;

	private float TransitionIn;
	// Use this for initialization
	void Start () {
	
		TransitionIn = 0.5f;
	}

	void OnTriggerEnter(Collider col){

		if(col.tag == "Player"){

            for(int i = 0; i < enteredArea.Length; i++){

                enteredArea[i].TransitionTo(TransitionIn);
            }
			
		}
	}
	

}
