using UnityEngine;
using System.Collections;

public class TutorialEventChecker : MonoBehaviour {
    public Animator tutorialCanvasAni;

    void Start()
    {
        StartCoroutine(MovementInWithDelay(1.0f));
    }

    public void MovementText()
    {
        tutorialCanvasAni.SetTrigger("MovementIn");
    }

    public void GravityChangeText()
    {
        tutorialCanvasAni.SetTrigger("GravityChangeIn");
    }

    public void ChangingSurfacesText()
    {
        tutorialCanvasAni.SetTrigger("ChangingSurfacesIn");
    }

    public void InteractText()
    {
        tutorialCanvasAni.SetTrigger("FadeInteractIn");
    }

    public void DropText()
    {
        tutorialCanvasAni.SetTrigger("DropIn");
    }

    public void SwitchPlatformText()
    {
        tutorialCanvasAni.SetTrigger("SwitchPlatformIn");
    }

    public void TargetText()
    {
        tutorialCanvasAni.SetTrigger("TargetIn");
    }

    public void FadeOut()
    {
        tutorialCanvasAni.SetTrigger("FadeOut");
    }

    IEnumerator MovementInWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        MovementText();
    }

}
