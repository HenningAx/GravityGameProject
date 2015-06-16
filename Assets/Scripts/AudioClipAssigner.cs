using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioClipAssigner : MonoBehaviour {


	public AudioClip[] AudioClips;
	public FallingObjectsAudioControll AudioControl;

	private int clipNum ;
	private AudioSource Source;

	void Awake(){


		Source = this.GetComponent<AudioSource>(); 

	}
	
	void Update () {


		Source.clip = AudioClips[AudioControl.clipNum];

	
	}
}
