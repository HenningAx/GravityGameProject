using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityStandardAssets.Characters.FirstPerson;


public class PlayerAudioControl : MonoBehaviour
{

    public AudioSource footsteps;


    private AudioSource source;
    private Rigidbody rigidbody;
    private RigidbodyFirstPersonController characterController;
    private GameObject Player;
    private float t = 0;
    bool BisFading = false;
    public float fadespeed = 0.05f;


    // Use this for initialization
    void Awake()
    {
        Player = transform.parent.gameObject;
        source = GetComponent<AudioSource>();
        rigidbody = Player.GetComponent<Rigidbody>();
        characterController = Player.GetComponent<RigidbodyFirstPersonController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.ProjectOnPlane(rigidbody.velocity, transform.up).sqrMagnitude > 0.5 * 0.5 && !source.isPlaying && characterController.Grounded)
        {
            StopAllCoroutines();
            StartCoroutine(AudioFadeIn(source, 1.0f));
            source.Play();
            BisFading = false;
        }
        else
        {
            
            if ((Vector3.ProjectOnPlane(rigidbody.velocity, transform.up).sqrMagnitude < 0.5 * 0.5 && source.isPlaying && !BisFading) || !characterController.Grounded)
            {
                StopAllCoroutines();
                StartCoroutine(AudioFadeOut(source, 1.0f));
                BisFading = true;
            }
        }
    }

    IEnumerator AudioFadeIn(AudioSource Clip, float Time)
    {
        while (t <= 1) {
        t += fadespeed;
        source.volume = MathExtensions.smootherstep(0,1,t);
        yield return null; 
        }
    }

    IEnumerator AudioFadeOut(AudioSource Clip, float Time)
    {
       // print(t);
        while (t > 0)
        {
           source.volume = MathExtensions.smootherstep(0, 1, t);
            t -= fadespeed;

            yield return null;
        }
        BisFading = false;
        source.Stop();
    }

}

