/* This script is used to let a lamp flicker
 * it manipulates the intensity of the light component and the emission of the material
 * the rate of the flicker, the chance that the light is on and the intensity of the light can be controlled
 */

using UnityEngine;
using System.Collections;

public class LampFlickerScript : MonoBehaviour {


    public AudioSource Clip;
    public int IflickerRate = 20;
    public float FlightChance = 0.8f;
    public float FlightIntensity = 0.8f;

    Light lightComp;
    Material materialComp;
    int Icountdown = 0;

	void Start () {
        lightComp = GetComponent<Light>();
        materialComp = GetComponent<Renderer>().material;
	}
	
	void Update () {
        if (Icountdown > IflickerRate)
        {
            //Calculate a random value between 0 and 1
            float newIntensity = Random.value;
            //If the value is higher than the chance to flicker the light is turned on
            if(newIntensity > FlightChance)
            {
                lightComp.intensity = FlightIntensity;
                materialComp.SetColor("_EmissionColor", Color.white); 
                Clip.Play();
            } else
            {
                lightComp.intensity = 0.0f;
                materialComp.SetColor("_EmissionColor", Color.black);
                Clip.Stop();
            }
            
            Icountdown = 0;
        }
        Icountdown++;
	}
}
