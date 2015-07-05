/* This script is used to rotate an object accordingly to the gravity and the mass point of the object
 * the object is only rotated around its forward axis
 * the upward direction of the object should point to the mass point
 * it also inherits from ButtonTarget to recieve a button input
 * while active the object rotates around its forward axis by a speed that can be set in the editor
 * when it receives a activate input from a button the object stops rotating and gets effected by gravity
 * when it receives a deactivate input from a button the object starts rotating and is not effected by gravity
 * */


using UnityEngine;
using System.Collections;

public class SpinningWheelScript : ButtonTarget
{

    //Inspector variables
    public float FrotSpeedSource;
    public float FrotSpeedActiveSource = 1.0f;
    public float FstopTime = 5.0f;
    public float FwheelDamage = 40.0f;

    //Local variables
    Quaternion TargetRot;
    Quaternion startRot;
    float FrotSpeedActive;
    float FstartTime;
    float FrotAngle;
    float FrotSpeed;
    bool BisRotating = false;
    bool BisActive = true;
    Vector3 VGravity;
    AudioSource FanSound;

    // Use this for initialization
    void Start()
    {
        VGravity = Physics.gravity;
        FanSound = GetComponent<AudioSource>();
        FrotSpeedActive = FrotSpeedActiveSource;

    }

    // Update is called once per frame
    void Update()
    {
        if (VGravity != Physics.gravity)
        {
            GravityChange();
        }

        if (BisRotating && !BisActive)
        {
            gameObject.smoothRotate(startRot, TargetRot, FrotAngle, FstartTime, FrotSpeed);
        }

        if (BisActive)
        {
            gameObject.transform.Rotate(transform.forward, FrotSpeedActive * Time.deltaTime, Space.World);
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
            startRot = transform.rotation;
            FrotSpeed = FrotSpeedSource * GravityProjected.magnitude;
            FstartTime = Time.time;
            BisRotating = true;
            FrotAngle = Quaternion.Angle(startRot, TargetRot);
        }

    }

    public override void TargetActivate()
    {
        //Stop the rotation
        base.TargetActivate();
        StartCoroutine(StopRot(FstopTime));
        StartCoroutine(AudioFadeOut(FanSound, FstopTime));
    }

    public override void TargetDeactivate()
    {
        //Start the rotation
        base.TargetDeactivate();
        StartCoroutine(StartRot(FstopTime));
        StartCoroutine(AudioFadeIn(FanSound, FstopTime));
    }

    IEnumerator AudioFadeOut(AudioSource Clip, float fadetime)
    {
        //Fade out the sound of the object
        float fadespeed = 1 / fadetime * Time.deltaTime;
        float t = 1;
        // print(t);
        while (t > 0)
        {
            Clip.volume = MathExtensions.smootherstep(0, 1, t);
            t -= fadespeed;

            yield return null;
        }
        Clip.Stop();
    }

    IEnumerator AudioFadeIn(AudioSource Clip, float fadetime)
    {
        //Fade in the sound of the object
        Clip.Play();
        Clip.volume = 0.0f;
        float fadespeed = 1 / fadetime * Time.deltaTime;
        float t = 0;
        while (t < 1)
        {
            Clip.volume = MathExtensions.smootherstep(0, 1, t);
            t += fadespeed;

            yield return null;
        }
        
    }

    //Coroutine to stop the rotation over a given time
    IEnumerator StopRot(float sTime)
    {
        float stopSpeed = 1 / sTime * Time.deltaTime;
        float t = 1;
        while (t > 0)
        {
            FrotSpeedActive = FrotSpeedActiveSource * MathExtensions.smootherstep(0, 1, t);
            t -= stopSpeed;

            yield return null;
        }
        GravityChange();
        BisActive = false;
    }

    //Coroutine to stop the rotation over a given time
    IEnumerator StartRot(float sTime)
    {
        BisActive = true;
        float stopSpeed = 1 / sTime * Time.deltaTime;
        float t = 0;
        while (t < 1)
        {
            FrotSpeedActive = FrotSpeedActiveSource * MathExtensions.smootherstep(0, 1, t);
            t += stopSpeed;

            yield return null;
        }
        
    }

    //Damage the player if he contacts with the active object
    void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "Player")
        {
            if (BisActive)
            {
                col.collider.GetComponent<HealthSystem>().TakeDamage(FwheelDamage);
            }
        }
    }
}
