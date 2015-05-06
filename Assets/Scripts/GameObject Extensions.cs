using UnityEngine;
using System.Collections;

public static class GameObjectExtensions
{
    public static bool smoothTranslate (this GameObject gameObject, Vector3 startPos, Vector3 targetPos, float distance, float startTime, float speed)
    {
        float distCovered = (Time.time - startTime) * speed;
        if (distance != 0)
        {
            //Move the door with ease in and ease out
            float moveFrac = distCovered / distance;
            float smoothDistance = MathExtensions.smootherstep(0, 1, moveFrac);
            gameObject.transform.position = Vector3.Lerp(startPos, targetPos, smoothDistance);
            if (moveFrac >= 1)
            {
                return false;
            } else
            {
                return true;
            }
        } 
        else
        {
            return false;
        }
    }
}
