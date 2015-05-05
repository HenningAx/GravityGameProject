using UnityEngine;
using System.Collections;

public static class DebugExtensions
{
    public static void DrawPoint(Vector3 point)
    {
        Debug.DrawRay(point, Vector3.up, Color.red, 5.0f);
        Debug.DrawRay(point, Vector3.down, Color.red, 5.0f);
        Debug.DrawRay(point, Vector3.back, Color.red, 5.0f);
        Debug.DrawRay(point, Vector3.forward, Color.red, 5.0f);
        Debug.DrawRay(point, Vector3.right, Color.red, 5.0f);
        Debug.DrawRay(point, Vector3.left, Color.red, 5.0f);
    }

    public static void DrawPoint(Vector3 point, Color color)
    {
        Debug.DrawRay(point, Vector3.up, color, 5.0f);
        Debug.DrawRay(point, Vector3.down, color, 5.0f);
        Debug.DrawRay(point, Vector3.back, color, 5.0f);
        Debug.DrawRay(point, Vector3.forward, color, 5.0f);
        Debug.DrawRay(point, Vector3.right, color, 5.0f);
        Debug.DrawRay(point, Vector3.left, color, 5.0f);
    }

    public static void DrawPoint(Vector3 point, float time)
    {
        Debug.DrawRay(point, Vector3.up, Color.red, time);
        Debug.DrawRay(point, Vector3.down, Color.red, time);
        Debug.DrawRay(point, Vector3.back, Color.red, time);
        Debug.DrawRay(point, Vector3.forward, Color.red, time);
        Debug.DrawRay(point, Vector3.right, Color.red, time);
        Debug.DrawRay(point, Vector3.left, Color.red, time);
    }

    public static void DrawPoint(Vector3 point, Color color, float time)
    {
        Debug.DrawRay(point, Vector3.up, color, time);
        Debug.DrawRay(point, Vector3.down, color, time);
        Debug.DrawRay(point, Vector3.back, color, time);
        Debug.DrawRay(point, Vector3.forward, color, time);
        Debug.DrawRay(point, Vector3.right, color, time);
        Debug.DrawRay(point, Vector3.left, color, time);
    }
}