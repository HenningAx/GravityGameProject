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
    Rigidbody pickUpObjectRigidbody;
    bool BhasObject = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(!BhasObject)
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 3.0f, Color.green, 5.0f);
            //Make a Raycast that only hits object on the "PickUpObjects" layer
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
                    //Set the main Camera as the new parent of the object
                    pickedUpRot = GpickUpObject.transform.rotation;
                    VtargetPosition = Camera.main.transform.position + Camera.main.transform.forward.normalized * Foffset;
                    Debug.DrawRay(VtargetPosition, Vector3.up, Color.red, 20.0f);
                    Debug.DrawRay(VtargetPosition, Vector3.down, Color.red, 20.0f);
                    Debug.DrawRay(VtargetPosition, Vector3.back, Color.red, 20.0f);
                    Debug.DrawRay(VtargetPosition, Vector3.forward, Color.red, 20.0f);
                    Debug.DrawRay(VtargetPosition, Vector3.right, Color.red, 20.0f);
                    Debug.DrawRay(VtargetPosition, Vector3.left, Color.red, 20.0f);
                    pickUpObjectRigidbody = GpickUpObject.GetComponent<Rigidbody>();
                    //Set the pickup object to kinematic
                    pickUpObjectRigidbody.useGravity = false;
                    pickUpObjectRigidbody.drag = 0;
                    pickUpObjectRigidbody.angularDrag = 100;
                }
            }

        }
        else
        {
            VtargetPosition = Camera.main.transform.position + Camera.main.transform.forward.normalized * Foffset;
            MoveToTargetWithDamp(GpickUpObject, VtargetPosition, FmoveDampning);
            //RotateToWithDamp(GpickUpObject, pickedUpRot, FrotDampning);
            if(Input.GetButtonDown("PickUp"))
            {
                BhasObject = false;
                pickUpObjectRigidbody.useGravity = true;
                pickUpObjectRigidbody.velocity = Vector3.zero;
                if (GoldParent != null)
                {
                    GpickUpObject.transform.parent = GoldParent.transform;
                }
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
