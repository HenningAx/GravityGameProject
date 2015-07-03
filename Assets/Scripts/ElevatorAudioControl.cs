using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class ElevatorAudioControl : MonoBehaviour
{

    public AudioSource slidingSource;
    public AudioClip Clip;
    public float delayMult;

    

    private Rigidbody rB;
    private float delayInSec;
    private bool played;
    
      

    void Awake()
    {
        rB = this.GetComponent<Rigidbody>();
        slidingSource.clip = Clip;
        played = false;
    }

    void Update()
    {
        delayInSec = delayMult / (rB.velocity.magnitude * rB.velocity.magnitude);
        PlaySound();
        
       
    }



    void PlaySound()
    {
        if (played)
        {
            StartCoroutine("Delay");
            
        }
        if (rB.velocity.magnitude > 0.5 && !played)
        {
          slidingSource.Play();
          played = true;
          StopAllCoroutines();

        }
    }

    IEnumerator Delay()

    {
        
        yield return new WaitForSeconds(delayInSec);
        
        print("just waited");
        played = false;
        
    }
    
}