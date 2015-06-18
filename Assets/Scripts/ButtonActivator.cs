using UnityEngine;
using System.Collections;

public class ButtonActivator : MonoBehaviour {

    public ButtonTarget[] targets;
    public float buttonDelay;

    bool playerInRange = false;

	// Use this for initialization
	void Start () {
	
	}

    IEnumerator delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
	

    public void ButtonActivate()
    {
        if (playerInRange)
        {
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
