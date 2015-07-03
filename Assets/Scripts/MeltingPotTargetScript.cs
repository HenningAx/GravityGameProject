using UnityEngine;
using System.Collections;

public class MeltingPotTargetScript : ButtonTarget {

    Rigidbody rbComp;
    public AudioSource[] ActivateVoice;
    public AudioSource ActivateSoundEffect;
    public AudioClip VoiceClip;
    public AudioClip EffectClip;

	// Use this for initialization
	void Start () {
        rbComp = this.GetComponent<Rigidbody>();
        ActivateSoundEffect.clip = EffectClip;
	
	}
	

    public override void TargetActivate()
    {
        base.TargetActivate();
        rbComp.isKinematic = false;
        foreach(AudioSource a in ActivateVoice)
        {
            a.clip = VoiceClip;
            a.Play();
        }
        ActivateSoundEffect.Play();
    }
}
