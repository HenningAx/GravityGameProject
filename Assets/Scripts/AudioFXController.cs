using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
public class AudioFXController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			this.GetComponent<AudioSource>().Play ();
		}
	
	}
}
