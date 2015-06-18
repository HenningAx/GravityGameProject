using UnityEngine;
using System.Collections;

public class RedLampTargetScript : ButtonTarget {

    public Color onColor;
    Light lightComp;
    Material materialComp;

	// Use this for initialization
	void Start () {
        lightComp = GetComponentInChildren<Light>();
        materialComp = GetComponent<MeshRenderer>().material;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void TargetActivate()
    {
        base.TargetActivate();
        lightComp.color = onColor;
        materialComp.SetColor("_EmissionColor", onColor);
    }
}
