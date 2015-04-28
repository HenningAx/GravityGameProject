using UnityEngine;
using System.Collections;

public class GravityChanger : MonoBehaviour {

    public float FRotSpeed = 1.0F;
    bool BisRotating = false;
    public GameObject Ground;
    Vector3 UpVector;
    Vector3 ForwardVector;
    Quaternion StartRot;
    Quaternion TargetRot;
    float FstartTime;
    float FjourneyLength;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Up"))
        {
            Physics.gravity = new Vector3(0, 9.81F, 0);
        }
        if(Input.GetButtonDown("Down"))
        {
            Physics.gravity = new Vector3(0, -9.81F, 0);
        }
        if(Input.GetButtonDown("Left"))
        {
            Physics.gravity = new Vector3(9.81F, 0, 0);
        }
        if(Input.GetButtonDown("Right"))
        {
            Physics.gravity = new Vector3(-9.81F, 0, 0);
        }


        if(BisRotating)
        {
            float FdistCovered = (Time.time - FstartTime) * FRotSpeed;
            transform.rotation = Quaternion.Slerp(StartRot, TargetRot, FdistCovered);
            SendMessage("setRotating", false);
            SendMessage("ReInitMouseLook");
            if(FdistCovered >= 1)
            {
                BisRotating = false;
                SendMessage("setRotating", false);
                SendMessage("ReInitMouseLook");
            }
        }
	
	}

    void OnCollisionEnter(Collision other)
    {
        Debug.DrawRay(transform.position, other.transform.position, Color.green, 100.0f);
        if(other.collider.tag == "Wand" && other.gameObject != Ground && !BisRotating)
        {
            FstartTime = Time.time;
            Ground = other.gameObject; 
            StartRot = transform.rotation;
            UpVector = other.transform.up;
            ForwardVector = Vector3.Cross(UpVector, transform.right) * -1;
            TargetRot = Quaternion.LookRotation(ForwardVector, UpVector);
            BisRotating = true;
            SendMessage("setRotating", true);
            Physics.gravity = other.transform.up * -9.81F;
        }
    }

    void OnTriggerEnter(Collider other)
    {
                if(other.tag == "ChangePlatform" && other.gameObject != Ground && !BisRotating)
                {
                    FstartTime = Time.time;
                    RaycastHit hit;
                    if(Physics.Raycast(transform.position, transform.up, out hit))
                    {
                        Ground = hit.transform.gameObject;
                    }
                    StartRot = transform.rotation;
                    UpVector = hit.transform.up;
                    ForwardVector = Vector3.Cross(UpVector, transform.right) * -1;
                    TargetRot = Quaternion.LookRotation(ForwardVector, UpVector);
                    BisRotating = true;
                    SendMessage("setRotating", true);
                    Physics.gravity = hit.transform.up * -9.81F;
                }
    }
}
