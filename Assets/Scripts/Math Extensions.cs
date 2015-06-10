//This script contains usefull mathematic functions not inculed in Unity

using UnityEngine;
using System.Collections;

public static class MathExtensions
{
    public static float smootherstep(float edge0, float edge1, float x)
    {
        // Scale, and clamp x to 0..1 range
        x = Mathf.Clamp((x - edge0) / (edge1 - edge0), 0.0f, 1.0f);
        // Evaluate polynomial
        return x * x * x * (x * (x * 6 - 15) + 10);
    }

    public static Vector3 round(Vector3 v)
    {
        Vector3 roundedVector = new Vector3();
        roundedVector.x = Mathf.Round(v.x * 1000);
        roundedVector.x /= 1000;
        roundedVector.y = Mathf.Round(v.y * 1000);
        roundedVector.y /= 1000;
        roundedVector.z = Mathf.Round(v.z * 1000);
        roundedVector.z /= 1000;
        return roundedVector;
    }
}
