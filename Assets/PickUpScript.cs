using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour {

    public float Foffset = 2.0f;

    RaycastHit pickUpObjectHit;
    GameObject GpickUpObject;
    GameObject GoldParent = null;
    Vector3 VoffsetVector;
    Rigidbody pickUpObjectRigidbody;
    bool BhasObject = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
                    }
                    //Set the main Camera as the new parent of the object
                    GpickUpObject.transform.SetParent(Camera.main.transform);
                    GpickUpObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * Foffset;
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
            GpickUpObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * Foffset;
            if(Input.GetButtonDown("PickUp"))
            {
                BhasObject = false;
                pickUpObjectRigidbody.useGravity = true;
                GpickUpObject.transform.parent = null;
                GpickUpObject.transform.parent = GoldParent.transform;
                GoldParent = null;
            }
        }

	
	}
}
