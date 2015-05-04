using UnityEngine;
using System.Collections;

public class SpinningWheelScript : MonoBehaviour {

    //Predifined Rotations
    public GameObject LeftRot;
    public GameObject RightRot;
    public GameObject UpRot;
    public GameObject DownRot;
    public float FrotSpeedSource;

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

        //if(transform.parent.up.normalized == Physics.gravity.normalized)
        //{
        //    TargetRot = UpRot.transform.rotation;
        //}
        //else
        //{
        //    if(-transform.parent.up.normalized == Physics.gravity.normalized)
        //    {
        //        TargetRot = DownRot.transform.rotation;
        //    } 
        //    else
        //    {
        //        if(transform.parent.forward.normalized == Physics.gravity.normalized)
        //        {
        //            TargetRot = LeftRot.transform.rotation;
        //        }
        //        else
        //        {
        //            if(-transform.parent.forward.normalized == Physics.gravity.normalized)
        //            {
        //                TargetRot = RightRot.transform.rotation;
        //            }
        //        }
        //    }
        //}
        Vector3 GravityProjected = Vector3.ProjectOnPlane(Physics.gravity, transform.forward);
        if (GravityProjected.magnitude != 0)
        {
            TargetRot = Quaternion.LookRotation(transform.forward, GravityProjected);
            StartRot = transform.rotation;
            FrotSpeed = FrotSpeedSource * GravityProjected.magnitude;
            FstartTime = Time.time;
            BisRotating = true;
            FrotAngle = Quaternion.Angle(StartRot, TargetRot);
        }

    }

    float smootherstep(float edge0, float edge1, float x)
    {
        // Scale, and clamp x to 0..1 range
        x = Mathf.Clamp((x - edge0) / (edge1 - edge0), 0.0f, 1.0f);
        // Evaluate polynomial
        return x * x * x * (x * (x * 6 - 15) + 10);
    }
}
