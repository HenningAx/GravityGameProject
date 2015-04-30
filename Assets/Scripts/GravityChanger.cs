using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class GravityChanger : MonoBehaviour {

    public float FRotSpeed = 1.0F;

    CapsuleCollider CharacterCollider;
    Rigidbody RigidbodyComp;
    RaycastHit GroundRaycastHit;

    GameObject Ground;
    bool BisRotating = false;
    bool bOverEdge = false;
    Vector3 VCollisionPoint;
    Vector3 VUpVector;
    Vector3 VForwardVector;
    Vector3 VMovmentVector;
    Quaternion StartRot;
    Quaternion TargetRot;
    RigidbodyFirstPersonController FirstPersonControllerScript;
    float Timer;
    float FstartTime;
    float FjourneyLength;

	// Use this for initialization
	void Start () {
        CharacterCollider = gameObject.GetComponent<CapsuleCollider>();
        RigidbodyComp = gameObject.GetComponent<Rigidbody>();
        FirstPersonControllerScript = gameObject.GetComponent<RigidbodyFirstPersonController>();
	
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
            RaycastHit AttatchToWall;
            Physics.Raycast(transform.position, VCollisionPoint - transform.position, out AttatchToWall, 100.0f, 1 << 8);
            StartWalkingOnWall(AttatchToWall);

        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.collider.gameObject.name == Ground.name && !BisRotating)
        {
            VMovmentVector = RigidbodyComp.velocity;
            if(Physics.gravity.x != 0)
            {
                VMovmentVector.x = 0;
            }
            else
            {
                if (Physics.gravity.y != 0)
                {
                    VMovmentVector.y = 0;
                } 
                else
                {
                    VMovmentVector.z = 0;
                }
            }
            Vector3 RayCastStart = transform.position - (transform.up * CharacterCollider.height/2);
            Vector3 RayCastDir = (VMovmentVector.normalized * CharacterCollider.radius * -1) + (transform.up * CharacterCollider.radius * -8); 
            RaycastHit hit;
            if (Physics.Raycast(RayCastStart, RayCastDir, out hit, 5.0f, 1<<8))
            {
                StartWalkingOnWall(hit);
            }
            RigidbodyComp.AddForce(transform.up * -100 / RigidbodyComp.velocity.magnitude, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
                if(other.tag == "ChangePlatform" && other.gameObject != Ground && !BisRotating)
                {
                    RaycastHit hit;
                    if(Physics.Raycast(transform.position, transform.up, out hit))
                    {
                        StartWalkingOnWall(hit);
                    }   
                }
    }

    void StartWalkingOnWall(RaycastHit Wall)
    {
        FstartTime = Time.time;
        Ground = Wall.collider.gameObject;
        StartRot = transform.rotation;
        VUpVector = Wall.normal;
        TargetRot = Quaternion.Euler(Vector3.Cross(VUpVector, transform.up).normalized * -Vector3.Angle(VUpVector, transform.up)) * transform.rotation;
        BisRotating = true;
        SendMessage("setRotating", true);
        Physics.gravity = Wall.normal * -9.81F;
    }
    
}
