using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class TransitionToSnaphotScript : MonoBehaviour {


	public AudioMixerSnapshot 	withinArea;

	private float TransitionIn;
	// Use this for initialization
	void Start () {
	
		TransitionIn = 1;
	}

	void OnTriggerEnter(Collider col){

		if(col.tag == "Player"){

			withinArea.TransitionTo(TransitionIn);
		}
	}
	

}
