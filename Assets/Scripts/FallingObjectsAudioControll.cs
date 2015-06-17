using UnityEngine;
using System.Collections;

public class FallingObjectsAudioControll : MonoBehaviour
{


    public AudioClip[] OnStone;
    public AudioClip[] OnMetal;
    public AudioClip[] OnWood;


    private AudioSource FallingSound;
    private float volumMult;

    private Rigidbody rb;

    
    



    void Awake()
    {
        FallingSound = this.GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody>();
    }



 

    void OnCollisionEnter(Collision col)
    {
        if (!FallingSound.isPlaying && rb.useGravity && !(col.collider.tag == "Player") )
        {
            volumMult = col.relativeVelocity.magnitude * 1 / 10;
            int materialIndex = 0;
            //Check what the Surface hit is made of

            //if (col.gameObject.GetComponentInParent<MeshRenderer>().materials[materialIndex].name.Contains("_Stone"))
            //{ 
            //    PlaySound(OnStone);                

            //}

            //if (col.gameObject.GetComponentInParent<MeshRenderer>().materials[materialIndex].name.Contains("_Metal"))
            //{
            //    PlaySound(OnMetal);

            //}

            //if (col.gameObject.GetComponentInParent<MeshRenderer>().materials[materialIndex].name.Contains("_Wood"))
            //{
            //    PlaySound(OnWood);

            //}
            PlaySound(OnStone);

        }





    }

    void PlaySound(AudioClip[] clips)
    {


        int clipNum = Random.Range(0, clips.Length);
        FallingSound.clip = clips[clipNum];
        FallingSound.Play();
        FallingSound.volume = volumMult;
        print("play");
    }

    

}


    
