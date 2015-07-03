using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class TransitionToSnapshot : MonoBehaviour {

    public AudioMixerSnapshot[] Snapshots;
    public float transitionTime;

    void Awake()
    {

        transitionTime = 0.5f;
    }

	
	void OnTriggerEnter (Collider col) {
	
        if(col.tag == "Player")
        {
            for (int i = 0; i < Snapshots.Length; i++)
            {
                Snapshots[i].TransitionTo(transitionTime);
            }

        }
	}
}
