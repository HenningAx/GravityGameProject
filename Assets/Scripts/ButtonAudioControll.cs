using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class ButtonAudioControll : MonoBehaviour {

    public AudioSource activationSound;
    public AudioClip clip;

    private GameObject button;

    void Awake()
    {
        button = this.gameObject;
    }

}
