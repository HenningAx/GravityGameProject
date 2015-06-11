using UnityEngine;
using System.Collections;

public class GravityArrow : MonoBehaviour {
    public float FrotSpeed = 1;

    float FstartTime = 0;
    bool BisRotating = false;

    Quaternion StartRot;
    Quaternion TargetRot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (BisRotating)
        {
            float FdistCovered = (Time.time - FstartTime) * FrotSpeed;
            transform.localRotation = Quaternion.Slerp(StartRot, TargetRot, FdistCovered);
            if (FdistCovered >= 1)
            {
                BisRotating = false;
            }
        }
	}

    void UpdateUI()
    {
        BisRotating = true;
        StartRot = transform.localRotation;
        TargetRot = Quaternion.LookRotation(Physics.gravity.normalized, Vector3.Cross(Physics.gravity.normalized, transform.right));
        FstartTime = Time.time;
    }
}
