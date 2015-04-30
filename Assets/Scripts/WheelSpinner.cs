using UnityEngine;
using System.Collections;

public class WheelSpinner : MonoBehaviour {

    public float FRotSpeed = 1.0F;
    float FstartTime;

    Quaternion StartRot;
    Quaternion TargetRot;
    Quaternion CurrentRot;

    Vector3 VgravityRight = new Vector3 ( 1F, 0F, 0F);
    Vector3 VgravityLeft = new Vector3 (-1F, 0F, 0F);
    Vector3 VgravityTop = new Vector3 (0F, 1F, 0F);
    Vector3 VgravityBottom = new Vector3(0F, -1F, 0F);


    public GameObject RotRight;
    public GameObject RotLeft;
    public GameObject RotTop;
    public GameObject RotBottom;

   

 

   // Quaternion RotRight = Quaternion.EulerAngles(-20,0,0);
    //Quaternion RotLeft = Quaternion.EulerAngles(160,0,0);
    //Quaternion RotTop = Quaternion.EulerAngles(70,0,0);
    //Quaternion RotBottom = Quaternion.EulerAngles(250,0,0);



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	if(Physics.gravity.normalized == VgravityRight.normalized){

        StartRot = transform.rotation;
        TargetRot = RotRight.transform.rotation;

        float FdistCovered = (Time.time - FstartTime) * FRotSpeed;
            transform.rotation = Quaternion.Slerp(StartRot, TargetRot, FdistCovered);
    }
	}
}
