﻿/* This script is used to communicate from a button to a target
 * the target has to be assigned
 * the button can have a timer after which the targets get deactivated
 * while the timer is running, the button is playing a tick sound */




using UnityEngine;
using System.Collections;
using System;

public class ButtonActivator : MonoBehaviour {

    [Serializable]
    public class ButtonUIText
    {
        
        public Animator feedbackText;
        public string textTriggerName;
    }

    [Serializable]
    //Variables for the sound
    public class ButtonSound
    {
        public bool BhasSound = false;
        public AudioSource buttonClip;
        public bool BplayDelayedSound = false;
        public AudioSource delayedSound;
        public AudioSource tickSound;
    }

    [Serializable]
    //Variables for a timer
    public class ButtonTimer
    {
        public bool BhasTimer = false;
        public float Ftimer = 5.0f;
    }

    public bool BhasAnimation = false;
    public ButtonTarget[] targets;
    public float buttonDelay;
    public ButtonUIText buttonUIText = new ButtonUIText();
    public ButtonSound buttonSound = new ButtonSound();
    public ButtonTimer buttonTimer = new ButtonTimer();

    [HideInInspector]
    public bool BisActive = false;
    bool playerInRange = false;
    Animator animation;

	// Use this for initialization
	void Start () {
        if (BhasAnimation)
        {
            animation = this.GetComponent<Animator>();
        }
	
	
	}

    //Coroutine for activate the target with a delay
    IEnumerator delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        foreach (ButtonTarget t in targets)
        {
            t.TargetActivate();
        }
        if (buttonTimer.BhasTimer)
        {
            StartCoroutine(ButtonCountdown(buttonTimer.Ftimer));
        }
        if (buttonSound.BplayDelayedSound)
        {
            buttonSound.delayedSound.Play();
        }
    }
	
    //Method that is called when the button is activated
    public void ButtonActivate()
    {
        if (playerInRange && !BisActive)
        {
            if (BhasAnimation)
            {
                animation.SetTrigger("Activate");
            }

            if (buttonUIText.feedbackText != null)
            {
                buttonUIText.feedbackText.SetTrigger(buttonUIText.textTriggerName);
            }

            if (buttonSound.BhasSound)
            {
                buttonSound.buttonClip.Play();
            }

            BisActive = true;

            if (buttonDelay > 0)
            {             
                StartCoroutine(delay(buttonDelay));
            } else
            {
                foreach (ButtonTarget t in targets)
                {
                    t.TargetActivate();
                }
                if (buttonTimer.BhasTimer)
                {
                    StartCoroutine(ButtonCountdown(buttonTimer.Ftimer));
                }
            }    
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerInRange = false;
        }
    }

    public bool GetInRange()
    {
        return playerInRange;
    }

    //Coroutine for the button timer
    IEnumerator ButtonCountdown(float timer)
    {
        int countdown = (int) (timer / Time.deltaTime);
        //Starting the tick sound
        StartCoroutine(PlayTickSound(countdown));
        yield return new WaitForSeconds(timer);
        //Deactivate the targets after the timer ran out
        foreach(ButtonTarget b in targets)
        {
            b.TargetDeactivate();
        }
        BisActive = false;
        if(BhasAnimation)
        {
            animation.SetTrigger("Deactivate");
        }
        StopAllCoroutines();
    }

    //Coroutine for playing the tick sound, giving the player feedback over the button timer
    IEnumerator PlayTickSound(int countdown)
    {
        float tickTimer = 4.0f;
        float startTime = Time.time;
        //While the button is active the tick sound is played
        while(BisActive)
        {
            yield return new WaitForSeconds(tickTimer);
            buttonSound.tickSound.Play();
            if (tickTimer > 0.2f)
            {
                //The sound between the ticks is reduced
                tickTimer -= tickTimer / ((buttonTimer.Ftimer - (Time.time - startTime)) / tickTimer);
            }
            else
            {
                tickTimer = 0.2f;
            }
            print(tickTimer);
        }
    }
}
