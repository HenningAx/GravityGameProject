using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class Shortcuts
{
    [MenuItem("Shortcuts/ Add BoxCollider &b")]
    private static void AddBoxCollider()
    {
        GameObject SelectedObj = Selection.activeGameObject;
        Undo.AddComponent<BoxCollider>(SelectedObj);
        Debug.Log("added Collider to " + Selection.activeGameObject.name);
    }

    [MenuItem("Shortcuts/ Get Objects from Selection without Collider")]
    private static void SelectWithoutCollider()
    {
        Transform[] SelectedObjects = Selection.transforms;
        List<GameObject> NewSelection = new List<GameObject>();
        foreach (Transform obj in SelectedObjects)
        {
            if(obj.gameObject.GetComponent<Collider>() == null)
            {
                NewSelection.Add(obj.gameObject);
            }
        }
        Selection.objects = NewSelection.ToArray();
    }
}