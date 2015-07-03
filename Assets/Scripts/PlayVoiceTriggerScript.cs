using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class PlayVoiceTriggerScript : MonoBehaviour {

    public AudioSource[] soundSource;
    public AudioClip clip;
    

    
    private bool BwasPlayed = false;

    void Awake()
    {
        BwasPlayed = false;
        foreach(AudioSource a in soundSource)
        {
            a.clip = clip;
        }
    }



    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && !BwasPlayed)
        {
            foreach (AudioSource a in soundSource)
            {
                a.clip = clip;
                a.Play();
            }
            BwasPlayed = true;
        }
    }

  
}
