//A script to capture screenshots

using UnityEngine;
using System.Collections;

public class ScreenshotCapture : MonoBehaviour {

    int ScreenshotNum = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Screenshot"))
        {
            Application.CaptureScreenshot("Screenshot" + ScreenshotNum+ ".png", 2);
            ScreenshotNum++;
        }
	}
}
