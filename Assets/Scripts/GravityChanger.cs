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
    Vector3 VCollisionPoint;
    Vector3 VUpVector;
    Vector3 VForwardVector;
    Vector3 VMovmentVector;
    Quaternion StartRot;
    Quaternion TargetRot;
    RigidbodyFirstPersonController FirstPersonControllerScript;
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
            Vector3 RayCastStart;
            RayCastStart = transform.position - (transform.up * CharacterCollider.height/2);
            Vector3 RayCastDir = (VMovmentVector.normalized * CharacterCollider.radius * -1) + (transform.up * CharacterCollider.radius * -8); 
            RaycastHit hit;
            Debug.DrawRay(RayCastStart, RayCastDir.normalized * 5, Color.yellow, 100.0f);

            if (Physics.Raycast(RayCastStart, RayCastDir, out hit, 5.0f, 1<<8))
            {
                Debug.Log(hit.collider.name);
                FstartTime = Time.time;
                StartRot = transform.rotation;
                VUpVector = hit.normal;
                VForwardVector = Vector3.Cross(VUpVector, transform.right) * -1;
                TargetRot = Quaternion.LookRotation(VForwardVector, VUpVector);
                RigidbodyComp.AddForce(VForwardVector * 100 / RigidbodyComp.velocity.magnitude, ForceMode.Impulse);
                BisRotating = true;
                SendMessage("setRotating", true);
                Physics.gravity = hit.normal * -9.81F;
            }
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
