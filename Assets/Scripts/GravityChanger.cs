using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class GravityChanger : MonoBehaviour {

    public float FRotSpeedEdge = 1.0F;
    public float FRotSpeedFlip = 2.0F;
    public float FMinimumObjectSizeToWalkOn = 2.0f;

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
    float Timer;
    float FstartTime;
    float FjourneyLength;
    float FRotSpeed;

	// Use this for initialization
	void Start () {
        CharacterCollider = gameObject.GetComponent<CapsuleCollider>();
        RigidbodyComp = gameObject.GetComponent<Rigidbody>();
	
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
            //Get the vector in which direction the player moves
            VMovmentVector = RigidbodyComp.velocity;
            //Project the vector on the plane the character is walking on 
            VMovmentVector = Vector3.ProjectOnPlane(VMovmentVector, transform.up);
            Vector3 RayCastStart = transform.position - (transform.up * CharacterCollider.height/2);
            Vector3 RayCastDir = (VMovmentVector.normalized * CharacterCollider.radius * -1) + (transform.up * CharacterCollider.radius * -FMinimumObjectSizeToWalkOn); 
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
        //Check if the Trigger is a platform to change gravity
                if(other.tag == "ChangePlatform" && other.gameObject != Ground && !BisRotating)
                {
                    //Sent an Raycast straight upwards to find the new ground of the Player
                    RaycastHit hit;
                    if(Physics.Raycast(transform.position, transform.up, out hit))
                    {
                        //Flip the Gravity using the surface hit by the Raycast
                        FlipGravity(hit);
                    }   
                }
    }

    void StartWalkingOnWall(RaycastHit Wall)
    {
        //Set Start Time of Rotating Animation
        FstartTime = Time.time;

        //Set Animation Speed
        FRotSpeed = FRotSpeedEdge;

        //Set the new Ground the Player is walking on
        Ground = Wall.collider.gameObject;

        //Callculate the new rotation
        StartRot = transform.rotation;
        VUpVector = Wall.normal;
        TargetRot = Quaternion.Euler(Vector3.Cross(VUpVector, transform.up).normalized * -Vector3.Angle(VUpVector, transform.up)) * transform.rotation;

        //Set the Character in RotationState
        BisRotating = true;
        SendMessage("setRotating", true);

        //Change Gravity
        Physics.gravity = Wall.normal * -9.81F;
    }

    void FlipGravity(RaycastHit Wall)
    {
        //Set Start Time of Rotating Animation
        FstartTime = Time.time;

        //Set Animation Speed
        FRotSpeed = FRotSpeedFlip;

        //Set the new Ground the Player is walking on
        Ground = Wall.collider.gameObject;

        //Callculate the new rotation
        StartRot = transform.rotation;
        VUpVector = Wall.normal;
        VForwardVector = Vector3.Cross(VUpVector, transform.right) * -1;
        TargetRot = Quaternion.LookRotation(VForwardVector, VUpVector);

        //Set the Character in RotationState
        BisRotating = true;
        SendMessage("setRotating", true);

        //Change Gravity
        Physics.gravity = Wall.normal * -9.81F;

    }
    
}
