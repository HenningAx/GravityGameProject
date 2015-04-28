using UnityEngine;
using System.Collections;

public class GravityChanger : MonoBehaviour {

    public float FRotSpeed = 1.0F;

    CapsuleCollider CharacterCollider;

    GameObject Ground;
    bool BisRotating = false;
    Vector3 VCollisionPoint;
    Vector3 VUpVector;
    Vector3 VForwardVector;
    Quaternion StartRot;
    Quaternion TargetRot;
    float FstartTime;
    float FjourneyLength;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

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
        
        if(other.collider.tag == "Wand" && other.gameObject != Ground && !BisRotating)
        {
            VCollisionPoint = other.contacts[0].point;
            Debug.DrawRay(transform.position, (VCollisionPoint - transform.position) * 6, Color.red, 100.0f);
            RaycastHit AttatchToWall;
            Physics.Raycast(transform.position, VCollisionPoint - transform.position, out AttatchToWall, 100.0f, 1 << 8);
            FstartTime = Time.time;
            Ground = AttatchToWall.collider.gameObject; 
            StartRot = transform.rotation;
            VUpVector = AttatchToWall.normal;
            VForwardVector = Vector3.Cross(VUpVector, transform.right) * -1;
            TargetRot = Quaternion.LookRotation(VForwardVector, VUpVector);
            BisRotating = true;
            SendMessage("setRotating", true);
            Physics.gravity = AttatchToWall.normal * -9.81F;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.collider.gameObject.name == Ground.name)
        {
            Debug.Log("CollisionExit");
            Debug.DrawRay(transform.position, transform.up * -10, Color.yellow, 100.0f);
            Vector3 RayCastStart = transform.position;
            RayCastStart = RayCastStart - Physics.gravity.normalized * CharacterCollider.height;
            Debug.Log(RayCastStart);
            RaycastHit hit;
            /*if (Physics.Raycast(transform.position, transform.up, out hit))
            {
                StartRot = transform.rotation;
                VUpVector = hit.transform.up;
                VForwardVector = Vector3.Cross(VUpVector, transform.right) * -1;
                TargetRot = Quaternion.LookRotation(VForwardVector, VUpVector);
                BisRotating = true;
                SendMessage("setRotating", true);
                Physics.gravity = hit.transform.up * -9.81F;
            }*/
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
                    VUpVector = hit.transform.up;
                    VForwardVector = Vector3.Cross(VUpVector, transform.right) * -1;
                    TargetRot = Quaternion.LookRotation(VForwardVector, VUpVector);
                    BisRotating = true;
                    SendMessage("setRotating", true);
                    Physics.gravity = hit.transform.up * -9.81F;
                }
    }
}
