using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class GravityChanger : MonoBehaviour
{

    public float FRotSpeedEdge = 1.0F;
    public float FRotSpeedFlip = 2.0F;
    public float FMinimumObjectSizeToWalkOn = 2.0f;
    public float FOverEdgePush = 2.0F;

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
    RaycastHit LastHit;
    float Timer;
    float FstartTime;
    float FjourneyLength;
    float FRotSpeed;
    public Vector3 LastHitNormal;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CharacterCollider = gameObject.GetComponent<CapsuleCollider>();
        RigidbodyComp = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (BisRotating)
        {
            float FdistCovered = (Time.time - FstartTime) * FRotSpeed;
            transform.rotation = Quaternion.Slerp(StartRot, TargetRot, FdistCovered);
            SendMessage("setRotating", false);
            SendMessage("ReInitMouseLook");
            if (FdistCovered >= 1)
            {
                BisRotating = false;
                SendMessage("setRotating", false);
                SendMessage("ReInitMouseLook");
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Wand" && other.gameObject != Ground && !BisRotating)
        {
            VCollisionPoint = other.contacts[0].point;
            RaycastHit AttatchToWall;
            if (Physics.Raycast(transform.position, (VCollisionPoint + RigidbodyComp.velocity.normalized) - transform.position, out AttatchToWall, 2.0f, 1 << 8))
            {
                if (LastHitNormal != MathExtensions.round(AttatchToWall.normal) && LastHitNormal != MathExtensions.round(AttatchToWall.normal) * -1)
                {
                    Debug.Log("StopMouseMoveByEnter");
                    StartWalkingOnWall(AttatchToWall);
                }
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Wand" && !BisRotating)
        {
            //Get the vector in which direction the player moves
            VMovmentVector = RigidbodyComp.velocity;
            //Project the vector on the plane the character is walking on 
            VMovmentVector = Vector3.ProjectOnPlane(VMovmentVector, transform.up);
            Vector3 RayCastStart = transform.position - (transform.up * CharacterCollider.height / 3);
            Vector3 RayCastDir = (VMovmentVector.normalized * CharacterCollider.radius * -1) + (transform.up * CharacterCollider.radius * -FMinimumObjectSizeToWalkOn);
            RaycastHit hit;
            Debug.DrawRay(RayCastStart, RayCastDir.normalized * 5.0f, Color.green, 5.0f);
            if (Physics.Raycast(RayCastStart, RayCastDir, out hit, 5.0f, 1 << 8))
            {
                if (LastHitNormal != MathExtensions.round(hit.normal) && LastHitNormal != (MathExtensions.round(hit.normal) * -1))
                {
                    StartWalkingOnWall(hit);
                    Debug.Log("StopMouseMoveByExit");
                    RigidbodyComp.velocity = RigidbodyComp.velocity.normalized;
                    RigidbodyComp.AddForce(transform.up.normalized * -FOverEdgePush, ForceMode.Impulse);
                }
            }
            Debug.DrawRay(transform.position, transform.up.normalized * -FOverEdgePush, Color.red, 10.0f);
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
        Physics.gravity = Wall.normal * -10.0F;

        LastHit = Wall;
        LastHitNormal = MathExtensions.round(Wall.normal);
        BroadcastMessage("UpdateUI", SendMessageOptions.DontRequireReceiver);
    }

    void FlipGravity(Collider other)
    {
        if (other.gameObject != Ground && !BisRotating)
        {
            //Sent an Raycast straight upwards to find the new ground of the Player
            RaycastHit Wall;
            if (Physics.Raycast(transform.position, transform.up, out Wall))
            {
                //Flip the Gravity using the surface hit by the Raycast
                RigidbodyComp.velocity = Vector3.zero;

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
                Physics.gravity = Wall.normal * -10.0f;

                BroadcastMessage("UpdateUI", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

}
