using UnityEngine;
using System.Collections;

public class LampFlickerScript : MonoBehaviour {

    Light lightComp;
    Material materialComp;
    int Icountdown = 0;
    public int IflickerRate = 20;

	// Use this for initialization
	void Start () {
        lightComp = GetComponent<Light>();
        materialComp = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        if (Icountdown > IflickerRate)
        {
            float newIntensity = Random.value;
            if(newIntensity > 0.8f)
            {
                lightComp.intensity = 0.8f;
                materialComp.SetColor("_EmissionColor", Color.white);
            } else
            {
                lightComp.intensity = 0.0f;
                materialComp.SetColor("_EmissionColor", Color.black);
            }
            
            Icountdown = 0;
        }
        Icountdown++;
	}
}
