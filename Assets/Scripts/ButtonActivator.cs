using UnityEngine;
using System.Collections;

public class ButtonActivator : MonoBehaviour {

    public bool BhasAnimation = false;
    public Animator feedbackText;
    public string textTriggerName;


    public ButtonTarget[] targets;
    public float buttonDelay;

    bool playerInRange = false;
    Animator animation;

	// Use this for initialization
	void Start () {
        if (BhasAnimation)
        {
            animation = this.GetComponent<Animator>();
        }
	
	
	}

    IEnumerator delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
	

    public void ButtonActivate()
    {
        if (playerInRange)
        {
            if (BhasAnimation)
            {
                animation.SetTrigger("Activate");
            }

            if(feedbackText != null)
            {
                feedbackText.SetTrigger(textTriggerName);
            }

            if (buttonDelay > 0)
            {
                StartCoroutine(delay(buttonDelay));
            }

            foreach (ButtonTarget t in targets)
            {
                t.TargetActivate();
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
}
