//This script contains usefull functions related to Physics

using UnityEngine;
using System.Collections;

public static class PhysicFunctions
{
    public static void ExplodeOnImpact(Vector3 pos, float radius, float power, float upwards)
    {
        Collider[] affectedObjects = Physics.OverlapSphere(pos, radius);
        foreach (Collider hit in affectedObjects)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(power, pos, radius, upwards);
            }
        }
    }

    public static void ExplodeOnImpact(Vector3 pos, float radius, float power)
    {
        Collider[] affectedObjects = Physics.OverlapSphere(pos, radius);
        foreach (Collider hit in affectedObjects)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, pos, radius, 0.0f);
            }
        }
    }

    public static void ExplodeOnImpact(Vector3 pos, float radius, float power, Vector3 prvVelo)
    {
        Collider[] affectedObjects = Physics.OverlapSphere(pos, radius);
        foreach (Collider hit in affectedObjects)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = prvVelo;
                rb.AddExplosionForce(power, pos, radius, 0.0f);
            }
        }
    }

}
