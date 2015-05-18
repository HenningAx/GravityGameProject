using UnityEngine;
using System.Collections;

public class SlidingDoorsScript : MonoBehaviour {

    public float FmoveSpeedSource;
    public bool BdoubleSided;
    public bool BisLocked;

    Vector3 VoldGravity;
    Vector3 VstartPos;
    Vector3 VtargetPos;
    Vector3 VsourcePos;
    bool BisMoving;
    float FstartTime;
    float FmoveDistance;
    float FmoveSpeed;

	// Use this for initialization
	void Start () {
        VoldGravity = Physics.gravity;
        VsourcePos = transform.position;
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        if(VoldGravity != Physics.gravity)
        {
            if (BdoubleSided)
            {
                MoveDoorDouble();
            } else
            {
                MoveDoorSingle();
            }
        }

        if (BisMoving)
        {
            //float FdistCovered = (Time.time - FstartTime) * FmoveSpeed;
            //if (FmoveDistance != 0)
            //{
            //    //Move the door with ease in and ease out
            //    float FmoveFrac = FdistCovered / FmoveDistance;
            //    float FsmoothDistance = smootherstep(0, 1, FmoveFrac);
            //    transform.position = Vector3.Lerp(VstartPos, VtargetPos, FsmoothDistance);
            //    if (FmoveFrac >= 1)
            //    {
            //        BisMoving = false;
            //    }
            //}
            BisMoving = gameObject.smoothTranslate(VstartPos, VtargetPos, FmoveDistance, FstartTime, FmoveSpeed);
        }

        VoldGravity = Physics.gravity;
	
	}

    void MoveDoorDouble()
    {
        //Project the gravity vector on the forward-right plane of the object
        Vector3 GravityProjected = Vector3.ProjectOnPlane(Physics.gravity, transform.up);
        //Project the vector on the right-up plane to project it at the right axis of the object
        Vector3 GravityOnAxis = Vector3.ProjectOnPlane(GravityProjected, transform.forward);
        //if the magnitude of this vector is zero the object will not move because the gravity has no effect in the move direction of the object
        if (GravityProjected.magnitude != 0 && GravityOnAxis.magnitude > 0.001f && !BisLocked)
        {
            BisMoving = true;
            VstartPos = transform.position;
            VtargetPos = VsourcePos + this.GetComponent<Collider>().bounds.size.x * GravityOnAxis.normalized;
            FstartTime = Time.time;
            FmoveSpeed = FmoveSpeedSource * GravityProjected.magnitude/9.81f;
            FmoveDistance = (VtargetPos - VstartPos).magnitude;
        }
    }

    void MoveDoorSingle()
    {
        //Project the gravity vector on the forward-right plane of the object
        Vector3 GravityProjected = Vector3.ProjectOnPlane(Physics.gravity, transform.up);
        //Project the vector on the right-up plane to project it at the right axis of the object
        Vector3 GravityOnAxis = Vector3.ProjectOnPlane(GravityProjected, transform.right);
        //if the magnitude of this vector is zero the object will not move because the gravity has no effect in the move direction of the object
        if (GravityProjected.magnitude != 0 && GravityOnAxis.magnitude > 0.001f && !BisLocked)
        {
            if (Vector3.Dot(GravityOnAxis, transform.forward) > -0.00001f)
            {
                BisMoving = true;
                VstartPos = transform.position;
                VtargetPos = VsourcePos + this.GetComponent<Collider>().bounds.size.x * GravityOnAxis.normalized;
                FstartTime = Time.time;
                FmoveSpeed = FmoveSpeedSource * GravityProjected.magnitude / 9.81f;
                FmoveDistance = (VtargetPos - VstartPos).magnitude;
            }
            else
            {
                BisMoving = true;
                VstartPos = transform.position;
                VtargetPos = VsourcePos;
                FstartTime = Time.time;
                FmoveSpeed = FmoveSpeedSource * GravityProjected.magnitude / 9.81f;
                FmoveDistance = (VtargetPos - VstartPos).magnitude;
            }
        }
    }
    float smootherstep(float edge0, float edge1, float x)
    {
        // Scale, and clamp x to 0..1 range
        x = Mathf.Clamp((x - edge0) / (edge1 - edge0), 0.0f, 1.0f);
        // Evaluate polynomial
        return x * x * x * (x * (x * 6 - 15) + 10);
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
