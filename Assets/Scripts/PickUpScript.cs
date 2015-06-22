/* This script enables the player to pickup objects marked as pickup
 * the objects must contain a rigibody component
 * the object will smoothly follow the movements of the player
 * the dampning of this follow can be controlled
 */


using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour {

    public float Foffset = 2.0f;
    public float FmoveDampning = 1.0f;
    public float FrotDampning = 1.0f;
    public float FhighlightStrength = 0.005f;
    public Animator aniTarget;
    public Color HighlightColor;

    GameObject GpickUpObject;
    GameObject GlastRaycastHit;
    GameObject GoldParent = null;
    Vector3 VoffsetVector;
    Vector3 VtargetPosition;
    Quaternion pickedUpRot;
    Quaternion realtivRotation;
    Rigidbody pickUpObjectRigidbody;
    bool BhasObject = false;
    bool BdropTutorialPlayed = false;
    bool BpickUpTutorialPlayed = false;
    bool BSwitchPlatformTutorialPlayed = false;
    float ForiginalDrag;
    float ForiginalAngularDrag;

	
	void Update () {
        if(!BhasObject)
        {
            RaycastHit objectHit;
            //Make a Raycast that only hits objects on the "PickUpObjects" layer to check if the player is looking at a object that can be picked up that is in range
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 3.0f, out objectHit, 5.0f))
            {
                if(GlastRaycastHit != null && GlastRaycastHit != objectHit.collider.gameObject)
                {
                    UnhighlightObject(GlastRaycastHit);
                }
                //If the player hits the PickUp Button the object will be picked up
                    if (objectHit.collider.tag == "PickUp")
                    {
                        HighlightObject(objectHit.collider.gameObject);
                        if(!BpickUpTutorialPlayed)
                        {
                            aniTarget.SetTrigger("FadeInteractIn");
                            BpickUpTutorialPlayed = true;
                        }
                        GlastRaycastHit = objectHit.collider.gameObject;
                        if (Input.GetButtonDown("PickUp"))
                        {
                            
                            PickUpObject(objectHit);
                            if(!BdropTutorialPlayed && !GpickUpObject.name.Contains("SwitchPlatform"))
                            {
                                aniTarget.SetTrigger("DropIn");
                                BdropTutorialPlayed = true;
                            } else
                            {
                                if(!BSwitchPlatformTutorialPlayed)
                                {
                                    aniTarget.SetTrigger("SwitchPlatformIn");
                                    BSwitchPlatformTutorialPlayed = true;
                                }
                            }
                            UnhighlightObject(objectHit.collider.gameObject);
                        }
                    } else
                    {
                        if(objectHit.collider.tag == "Button")
                        {
                            if(objectHit.collider.GetComponent<ButtonActivator>().GetInRange())
                            {
                                if (Input.GetButtonDown("PickUp"))
                                {
                                    CallButton(objectHit);
                                }
                                HighlightObject(objectHit.collider.gameObject);
                                GlastRaycastHit = objectHit.collider.gameObject; 
                            }
                    }
                }
            } else
            {
                if(GlastRaycastHit != null)
                {
                    UnhighlightObject(GlastRaycastHit);
                }
            }

        }
            //Behaviour if the player has an object
        else
        {
            //Set the target position of the object to be infront of the camera of the player
            VtargetPosition = Camera.main.transform.position + Camera.main.transform.forward.normalized * Foffset;
            //Apply a velocity to the rigidbody towards the target position and rotate the object relative to the player 
            pickUpObjectRigidbody.velocity = (VtargetPosition - GpickUpObject.transform.position) * FmoveDampning;
            //pickUpObjectRigidbody.AddForce((VtargetPosition - GpickUpObject.transform.position) * FmoveDampning);
            //RotateToWithDamp(GpickUpObject, Camera.main.transform.rotation * realtivRotation, FrotDampning);
            //pickUpObjectRigidbody.angularVelocity = Quaternion.FromToRotation(GpickUpObject.transform.rotation, Camera.main.transform.rotation * realtivRotation);
            //If the player hits the PickUp button the object will be dropped
            if(Input.GetButtonDown("PickUp"))
            {

                //Set the state to not having an object
                BhasObject = false;
                //Reset the orignal values of the pick up
                pickUpObjectRigidbody.useGravity = true;
                pickUpObjectRigidbody.drag = ForiginalDrag;
                if (GoldParent != null)
                {
                    GpickUpObject.transform.parent = GoldParent.transform;
                }
                GoldParent = null;
                pickUpObjectRigidbody.angularDrag = ForiginalAngularDrag;
                //Reduce to velocity of the pick up to prevent extrem strong throws
                pickUpObjectRigidbody.velocity = pickUpObjectRigidbody.velocity / 3;
                //Tell the object it has been droped
                GpickUpObject.SendMessage("Droped", SendMessageOptions.DontRequireReceiver);
            }
        }
	}

    void MoveToTargetWithDamp(GameObject TargetObject, Vector3 TargetPos, float Dampning)
    {
        TargetObject.transform.position = Vector3.Lerp(TargetObject.transform.position, TargetPos, Dampning * Time.fixedDeltaTime);
    }

    void RotateToWithDamp(GameObject TargetObject, Quaternion TargetRot, float Dampning)
    {
        TargetObject.transform.rotation = Quaternion.Slerp(TargetObject.transform.rotation, TargetRot, Dampning * Time.fixedDeltaTime);
    }

    void PickUpObject(RaycastHit hit)
    {
        //Set that the player has an object
        BhasObject = true;

        //Save the picked up obejct
        GpickUpObject = hit.collider.gameObject;

        //Save the old parent of the picked up object
        if (GpickUpObject.transform.parent != null && GpickUpObject.transform.parent != Camera.main.transform)
        {
            GoldParent = GpickUpObject.transform.parent.gameObject;
            GpickUpObject.transform.parent = null;
        }

        //Tell the object that it is pickedup
        GpickUpObject.SendMessage("PickedUp", SendMessageOptions.DontRequireReceiver);

        //Set the new rotation of the pickup to be relative to the player rotation
        pickedUpRot = GpickUpObject.transform.rotation;
        realtivRotation = Quaternion.Inverse(this.transform.rotation) * pickedUpRot;

        //Set the new position of the object to be infront of the Camera of the player
        VtargetPosition = Camera.main.transform.position + Camera.main.transform.forward.normalized * Foffset;
        pickUpObjectRigidbody = GpickUpObject.GetComponent<Rigidbody>();

        //Set the object to not use gravity
        pickUpObjectRigidbody.useGravity = false;

        //Save the original drag of the pick up
        ForiginalDrag = pickUpObjectRigidbody.drag;
        ForiginalAngularDrag = pickUpObjectRigidbody.angularDrag;

        //Set the drag of the pick up to 0 and the angular drag to 100 to gurantee a smooth movement but to prevent it from rotating all the time
        pickUpObjectRigidbody.drag = 0;
        pickUpObjectRigidbody.angularDrag = 100;
    }

    void CallButton(RaycastHit hit)
    {
        hit.collider.GetComponent<ButtonActivator>().ButtonActivate();
    }

    void HighlightObject(GameObject obj)
    {
        MeshRenderer[] meshR = obj.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mR in meshR)
        {
            mR.material.SetColor("_OutlineColor", HighlightColor);
            mR.material.SetFloat("_Outline", FhighlightStrength);
        }
    }

    void UnhighlightObject(GameObject obj)
    {
        MeshRenderer[] meshR = obj.GetComponentsInChildren<MeshRenderer>(); 
        foreach (MeshRenderer mR in meshR)
        {
            mR.material.SetFloat("_Outline", 0f);
        }
    }
}
