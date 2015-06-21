using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

    public Animator EndText;

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            EndText.SetTrigger("End");
            StartCoroutine(WaitForEnd(30.0f));
        }
    }

    IEnumerator WaitForEnd(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.Quit();
    }
}
