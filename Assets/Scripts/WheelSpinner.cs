using UnityEngine;
using System.Collections;

public class WheelSpinner : MonoBehaviour {

    public float FrotSpeed = 1.0F;
    Quaternion StartRot;
    Quaternion TargetRot;
    Quaternion CurrentRot;

    Vector3 VgravityRight = new Vector3 (1.0.0);
    Vector3 VgravityLeft = new Vector3 (-1.0.0);
    Vector3 VgravityTop = new Vector3 (0.1.0);
    Vector3 VgravityBottom = new Vector3(0.-1.0);


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
	if(Gravity.physics.ormalize == VgravityRight.Normalize){

        StartRot = transform.rotation;
        TargetRot = RotRight;

        float FdistCovered = (Time.time - FstartTime) * FRotSpeed;
            transform.rotation = Quaternion.Slerp(StartRot, TargetRot, FdistCovered);
    }
	}
}
