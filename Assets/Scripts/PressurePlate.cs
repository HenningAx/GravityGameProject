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

	// Use this for initialization
	void Start () 
    {
        VoriginalPos = transform.position;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if(BisMoving)
        {
            BisMoving = gameObject.smoothTranslate(VstartPos, VtargetPos, FmoveDistance, FstartTime, FmoveSpeed);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Rigidbody>().mass >= FpressureThreshold)
        {
            GtargetObject.SendMessage("Activate", SendMessageOptions.DontRequireReceiver);
            BisMoving = true;
            FstartTime = Time.time;
            VstartPos = transform.position;
            VtargetPos = VoriginalPos - Vector3.up * this.GetComponent<MeshRenderer>().bounds.size.y * FpressedDistance;
            FmoveDistance = (VtargetPos - VstartPos).magnitude;
            GtriggerObject = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == GtriggerObject)
        {
            GtargetObject.SendMessage("DeActivate", SendMessageOptions.DontRequireReceiver);
            BisMoving = true;
            FstartTime = Time.time;
            VstartPos = transform.position;
            VtargetPos = VoriginalPos;
            FmoveDistance = (VtargetPos - VstartPos).magnitude;
        }
    }
}
