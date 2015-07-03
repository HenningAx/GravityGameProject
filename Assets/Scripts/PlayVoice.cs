using UnityEngine;
using System.Collections;

public class PlayVoice : MonoBehaviour {

    public AudioSource TargetAudio;
    bool Bplayed = false;

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !Bplayed)
        {
            TargetAudio.Play();
            Bplayed = true;
        }
    }
}
