using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour {

    public float Foffset = 2.0f;
    public float FmoveDampning = 1.0f;
    public float FrotDampning = 1.0f;

    RaycastHit pickUpObjectHit;
    GameObject GpickUpObject;
    GameObject GoldParent = null;
    Vector3 VoffsetVector;
    Vector3 VtargetPosition;
    Quaternion pickedUpRot;
    Quaternion realtivRotation;
    Rigidbody pickUpObjectRigidbody;
    bool BhasObject = false;
    float ForiginalDrag;
    float ForiginalAngularDrag;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(!BhasObject)
        {
            //Make a Raycast that only hits objects on the "PickUpObjects" layer
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 3.0f, out pickUpObjectHit, 5.0f, 1 << 9))
            {
                if (Input.GetButtonDown("PickUp"))
                {
                    BhasObject = true;

                    //Save the picked up obejct
                    GpickUpObject = pickUpObjectHit.collider.gameObject;

                    //Save the old parent of the picked up object
                    if (GpickUpObject.transform.parent != null && GpickUpObject.transform.parent != Camera.main.transform)
                    {
                        GoldParent = GpickUpObject.transform.parent.gameObject;
                        GpickUpObject.transform.parent = null;
                    }

                    GpickUpObject.SendMessage("PickedUp", SendMessageOptions.DontRequireReceiver);

                    //GpickUpObject.transform.SetParent(Camera.main.transform);

                    //Set the main Camera as the new parent of the object
                    pickedUpRot = GpickUpObject.transform.rotation;
                    realtivRotation = Quaternion.Inverse(this.transform.rotation) * pickedUpRot;
                    VtargetPosition = Camera.main.transform.position + Camera.main.transform.forward.normalized * Foffset;
                    pickUpObjectRigidbody = GpickUpObject.GetComponent<Rigidbody>();
                    //Set the pickup object to kinematic
                    pickUpObjectRigidbody.useGravity = false;
                    ForiginalDrag = pickUpObjectRigidbody.drag;
                    ForiginalAngularDrag = pickUpObjectRigidbody.angularDrag;
                    pickUpObjectRigidbody.drag = 0;
                    pickUpObjectRigidbody.angularDrag = 100;
                }
            }

        }
        else
        {
            VtargetPosition = Camera.main.transform.position + Camera.main.transform.forward.normalized * Foffset;
            pickUpObjectRigidbody.velocity = (VtargetPosition - GpickUpObject.transform.position) * FmoveDampning;
            RotateToWithDamp(GpickUpObject, Camera.main.transform.rotation * realtivRotation, FrotDampning);
            if(Input.GetButtonDown("PickUp"))
            {
                BhasObject = false;
                pickUpObjectRigidbody.useGravity = true;
                pickUpObjectRigidbody.velocity = Vector3.zero;
                pickUpObjectRigidbody.drag = ForiginalDrag;
                pickUpObjectRigidbody.angularDrag = ForiginalAngularDrag;
                if (GoldParent != null)
                {
                    GpickUpObject.transform.parent = GoldParent.transform;
                }
                GpickUpObject.transform.SetParent(null);
                GoldParent = null;
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
}
