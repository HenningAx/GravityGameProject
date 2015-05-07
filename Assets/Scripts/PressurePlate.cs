using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

    public GameObject GtargetObject;
    public float FmoveSpeed = 1;
    public float FpressedDistance = 1;
    public float FpressureThreshold;

    bool BisMoving = false;
    float FstartTime;
    float FmoveDistance;
    Vector3 VoriginalPos;
    Vector3 VstartPos;
    Vector3 VtargetPos;
    GameObject GtriggerObject;
    GameObject GpressurePlate;

	// Use this for initialization
	void Start () 
    {
        GpressurePlate = transform.FindChild("PressurePlate").gameObject;
        VoriginalPos = GpressurePlate.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if(BisMoving)
        {
            //Move the PressurePlate smooth over time
            BisMoving = GpressurePlate.gameObject.smoothTranslate(VstartPos, VtargetPos, FmoveDistance, FstartTime, FmoveSpeed);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Rigidbody>().mass >= FpressureThreshold)
        {
            //Call the Activate function on the target
            GtargetObject.SendMessage("Activate", SendMessageOptions.DontRequireReceiver);
            BisMoving = true;
            FstartTime = Time.time;
            VstartPos = GpressurePlate.transform.position;
            VtargetPos = VoriginalPos - Vector3.up * GpressurePlate.GetComponent<MeshRenderer>().bounds.size.y * FpressedDistance;
            FmoveDistance = (VtargetPos - VstartPos).magnitude;
            GtriggerObject = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == GtriggerObject)
        {
            //Call the Deactivate function on the target
            GtargetObject.SendMessage("DeActivate", SendMessageOptions.DontRequireReceiver);
            BisMoving = true;
            FstartTime = Time.time;
            VstartPos = GpressurePlate.transform.position;
            VtargetPos = VoriginalPos;
            FmoveDistance = (VtargetPos - VstartPos).magnitude;
        }
    }
}
