//A script to create a swinging door effected by gravity without using physics

using UnityEngine;
using System.Collections;

public class SwingingDoorScript : MonoBehaviour {
    public float FrotSpeedSource;
    public bool BisLocked;

    Vector3 Vgravity;
    Vector3 VoriginalForwardVector;
    Quaternion startRot;
    Quaternion targetRot;
    bool BisRotating = false;
    float FstartTime;
    float FrotAngle;
    float FrotSpeed;

	// Use this for initialization
	void Start () 
    {
        Vgravity = Physics.gravity;
        VoriginalForwardVector = transform.forward;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Vgravity != Physics.gravity)
        {
            GravityChange();
        }

        if (BisRotating)
        {
            gameObject.smoothRotate(startRot, targetRot, FrotAngle, FstartTime, FrotSpeed);
        }

        Vgravity = Physics.gravity;
	}

    void GravityChange()
    {
        //Project the gravity vector on the plane the wheel is onto
        Vector3 GravityProjected = Vector3.Project(Physics.gravity, transform.forward);
        //if the magnitude of this vector is zero the wheel will not spin because the gravity parallel to the axis of the wheel
        if (GravityProjected.magnitude != 0 && Vector3.Dot(VoriginalForwardVector, Physics.gravity) >= -0.0001f)
        {
            //Get the new rotation of the wheel by making the up vector of the wheel, which is facing the heayiest point of the wheel, the same as the projected gravity vector
            //Because the gravity vector is projected to the plan of the wheel, the wheel can only spin around its forward axis, which is parralel to its physic axis
            targetRot = Quaternion.LookRotation((Quaternion.AngleAxis(90, transform.up) * Vector3.ProjectOnPlane(Physics.gravity, transform.up)), transform.up);
            startRot = transform.rotation;
            FrotSpeed = FrotSpeedSource * GravityProjected.magnitude;
            FstartTime = Time.time;
            BisRotating = true;
            FrotAngle = Quaternion.Angle(startRot, targetRot);
        }

    }
    void Activate()
    {
        BisLocked = false;
    }

    void DeActivate()
    {
        BisLocked = true;
    }
}
