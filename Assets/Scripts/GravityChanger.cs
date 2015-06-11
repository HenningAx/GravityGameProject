/* This script is used for the gravity changing of the character
 * when the character hits something which is marked as Wall or walks over a edge where the next surface is marked as Wall the gravity changes
 * it also contains a function to switch the gravity around which is used by the switch platforms
 * it also handels the rotation of the character when the gravity changes
 */

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
    RigidbodyFirstPersonController CharacterControllerScript;
    Rigidbody RigidbodyComp;

    GameObject Ground;
    bool BisRotating = false;
    Vector3 VCollisionPoint;
    Vector3 VUpVector;
    Vector3 VForwardVector;
    Vector3 VMovmentVector;
    Vector3 VlastGravity;
    Quaternion StartRot;
    Quaternion TargetRot;
    RaycastHit LastHit;
    float FstartTime;
    float FRotSpeed;
    public Vector3 LastHitNormal;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        CharacterCollider = gameObject.GetComponent<CapsuleCollider>();
        CharacterControllerScript = GetComponent<RigidbodyFirstPersonController>();
        RigidbodyComp = gameObject.GetComponent<Rigidbody>();
        LastHitNormal = Physics.gravity.normalized;
    }

    //Couroutine to rotate the character
    IEnumerator RotateSequence()
    {
        while (BisRotating)
        {
            float FdistCovered = (Time.time - FstartTime) * FRotSpeed;
            transform.rotation = Quaternion.Slerp(StartRot, TargetRot, FdistCovered);
            if (FdistCovered >= 1)
            {
                BisRotating = false;
                CharacterControllerScript.setRotating(false);
                CharacterControllerScript.ReInitMouseLook();
            }
            yield return null;
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
            if (Physics.Raycast(RayCastStart, RayCastDir, out hit, 5.0f))
            {
                if (LastHitNormal != MathExtensions.round(hit.normal) && LastHitNormal != (MathExtensions.round(hit.normal) * -1) && hit.collider.tag == "Wand")
                {
                    StartWalkingOnWall(hit);
                    //Apply some force to push the character over the edge
                    RigidbodyComp.velocity = RigidbodyComp.velocity.normalized;
                    RigidbodyComp.AddForce(VlastGravity.normalized * FOverEdgePush, ForceMode.Impulse);
                }
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
        //Get the new rotation by creating a rotation, that rotates around the axis between the current and the new up Vector
        TargetRot = Quaternion.AngleAxis(-Vector3.Angle(VUpVector, transform.up), Vector3.Cross(VUpVector, transform.up).normalized) * transform.rotation;
        Quaternion TargetUpRot = Quaternion.Euler(Vector3.Cross(VUpVector, transform.up).normalized * -Vector3.Angle(VUpVector, transform.up)) * transform.rotation;

        //Set the Character in RotationState
        BisRotating = true;
        CharacterControllerScript.setRotating(true);

        //Change Gravity
        VlastGravity = Physics.gravity;
        Physics.gravity = Wall.normal * -10.0F;

        LastHit = Wall;
        LastHitNormal = MathExtensions.round(Wall.normal);
        BroadcastMessage("UpdateUI", SendMessageOptions.DontRequireReceiver);
        StartCoroutine(RotateSequence());
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
                CharacterControllerScript.setRotating(true);

                //Change Gravity
                VlastGravity = Physics.gravity;
                Physics.gravity = Wall.normal * -10.0f;

                BroadcastMessage("UpdateUI", SendMessageOptions.DontRequireReceiver);
                StartCoroutine(RotateSequence());
            }
        }
    }

}
