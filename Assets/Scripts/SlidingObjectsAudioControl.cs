using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class SlidingObjectsAudioControl : MonoBehaviour {

    public AudioSource slidingSource;
    public AudioSource stoppingSource;
    public float fadespeed = 0.05f;
    public float FmovingThreshold = 0.2f;

    private Rigidbody rB;
    private float t = 0;
    bool BisFading = false;

    private bool moved;

    void Awake()
    {
        rB = this.GetComponent<Rigidbody>();
        moved = false;

    }

    void Update()
    {

        PlaySound(rB.velocity.magnitude);
        
    }



    void PlaySound(float vel)
    {
        if (vel > FmovingThreshold && !slidingSource.isPlaying)
        {
            stoppingSource.Stop();
            slidingSource.Play();
            moved = true;
        } 

        if(vel < FmovingThreshold)
        {
            StopAllCoroutines();
            StartCoroutine(AudioFadeOut(stoppingSource, fadespeed));
            moved = false;
        }
    }

    IEnumerator AudioFadeOut(AudioSource Clip, float Time)
    {
        // print(t);
        while (t > 0)
        {
            slidingSource.volume = MathExtensions.smootherstep(0, 1, t);
            t -= fadespeed;

            yield return null;
        }
        BisFading = false;
        slidingSource.Stop();
    }

    void OnCollisionEnter(Collision col)
    {
            if (moved)
            {
                slidingSource.Stop();
                stoppingSource.Play();
                moved = false;
            }
        
    }
}
