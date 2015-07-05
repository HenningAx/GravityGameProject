﻿/* This script is used to create a piston
 * the piston contains multiple objects
 * the objects of the piston must be childs of the object this script is attached to
 * the maxium position of the piston is the starting position
 * */



using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Child
{
    public Transform trans;
    public Vector3 positionOffset;

    public Child(Transform t)
    {
        trans = t;
        positionOffset = t.position;
    }
}

public class PistonScript : MonoBehaviour {



    public List<Child> Childs = new List<Child>();
    Vector3 VparentOffset;
    Vector3 VmaxPos;

	// Use this for initialization
	void Awake () {
        VmaxPos = transform.position;
        VparentOffset = transform.position;
        Transform ChildTemp = transform;
        int IchildNumber = 0;
        //Get the childs to have all objects of the piston
        while(ChildTemp.childCount != 0)
        {
            Childs.Add(new Child(ChildTemp.GetChild(0)));
            ChildTemp = ChildTemp.GetChild(0);
            IchildNumber++;
            //Secure mechanism to not run into infinte loops
            if(IchildNumber >= 100)
            {
                throw new Exception("Infinite Loop or to many childs");
            }
        }
	}
	
	void FixedUpdate () {
        if(transform.position.y < VmaxPos.y)
        {
            for (int i = 0; i < Childs.Count; i++)
            {
                //Move the childs relative to the parent to create a piston effect
                float MovementMultiplier = (Childs.Count - i) / (float)Childs.Count;
                Childs[i].trans.position = Childs[i].positionOffset + (transform.position - VparentOffset) * MovementMultiplier;
            }
        } else
        {
            //Limit the movment if the piston is fully strechted 
            this.GetComponent<Rigidbody>().MovePosition(VmaxPos);
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
	}
}
