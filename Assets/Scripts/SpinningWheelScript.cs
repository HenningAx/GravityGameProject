using UnityEngine;
using System.Collections;

public class SpinningWheelScript : MonoBehaviour {

    //Inspector variables
    public float FrotSpeedSource;

    //Local variables
    Quaternion TargetRot;
    Quaternion StartRot;
    float FstartTime;
    float FrotAngle;
    float FrotSpeed;
    bool BisRotating = false;
    Vector3 VGravity;

	// Use this for initialization
	void Start () {
        VGravity = Physics.gravity;
	
	}
	
	// Update is called once per frame
	void Update () {
        if(VGravity != Physics.gravity)
        {
            GravityChange();
        }

        if (BisRotating)
        {
            float FdistCovered = (Time.time - FstartTime) * FrotSpeed;
            if (FrotAngle != 0)
            {
                //Rotate the wheel with ease in and ease out
                float FrotFrac = FdistCovered / FrotAngle;
                //float FsmoothDistance = Mathf.SmoothStep(0, 1, FrotFrac);
                float FsmoothDistance = smootherstep(0, 1, FrotFrac);
                transform.rotation = Quaternion.Slerp(StartRot, TargetRot, FsmoothDistance);
                if (FrotFrac >= 1)
                {
                    BisRotating = false;
                }
            }
        }

        VGravity = Physics.gravity;

	
	}

    void GravityChange()
    {
        //Project the gravity vector on the plane the wheel is onto
        Vector3 GravityProjected = Vector3.ProjectOnPlane(Physics.gravity, transform.forward);
        //if the magnitude of this vector is zero the wheel will not spin because the gravity parallel to the axis of the wheel
        if (GravityProjected.magnitude != 0)
        {
            //Get the new rotation of the wheel by making the up vector of the wheel, which is facing the heayiest point of the wheel, the same as the projected gravity vector
            //Because the gravity vector is projected to the plan of the wheel, the wheel can only spin around its forward axis, which is parralel to its physic axis
            TargetRot = Quaternion.LookRotation(transform.forward, GravityProjected);
            StartRot = transform.rotation;
            FrotSpeed = FrotSpeedSource * GravityProjected.magnitude;
            FstartTime = Time.time;
            BisRotating = true;
            FrotAngle = Quaternion.Angle(StartRot, TargetRot);
        }

    }

    //Very smooth interpolate between f1 und f2
    float smootherstep(float edge0, float edge1, float x)
    {
        // Scale, and clamp x to 0..1 range
        x = Mathf.Clamp((x - edge0) / (edge1 - edge0), 0.0f, 1.0f);
        // Evaluate polynomial
        return x * x * x * (x * (x * 6 - 15) + 10);
    }
}
