/* This script limits the movement of a rigidbody to stay inside the min and max pos
 * only works if the movment is in the forward direction only
 * the movment is limited by the bounds of the object collider
 * */


using UnityEngine;
using System.Collections;

public class RBMoveLimiter : MonoBehaviour {

    Collider objectCollider;
    Vector3 VRealtiveForwardVector;
    Vector3 VMinPos;
    Vector3 VMaxPos;
    float FminPosValue;
    float FmaxPosValue;


	void Start () {
        objectCollider = GetComponentInChildren<Collider>();
        VRealtiveForwardVector = objectCollider.transform.rotation * transform.forward;
        VMinPos = transform.position;
        Vector3 minPosForwardComp = Vector3.Scale(VMinPos, transform.forward);
        FminPosValue = minPosForwardComp.x + minPosForwardComp.y + minPosForwardComp.z;
        VMaxPos = transform.position;
        VMaxPos += transform.forward * Vector3.Scale(objectCollider.bounds.size, VRealtiveForwardVector).magnitude;
        Vector3 maxPosForwardComp = Vector3.Scale(VMaxPos, transform.forward);
        FmaxPosValue = maxPosForwardComp.x + maxPosForwardComp.y + maxPosForwardComp.z;
	}
	
	void Update () {
        Vector3 posForwardComp = Vector3.Scale(transform.position, transform.forward);
        float forwardValue = posForwardComp.x + posForwardComp.y + posForwardComp.z;
        if (forwardValue < FminPosValue)
        {
            transform.position = VMinPos;
        } else
        {
            if(forwardValue > FmaxPosValue)
            {
                transform.position = VMaxPos;
            }
        }
	}
}
