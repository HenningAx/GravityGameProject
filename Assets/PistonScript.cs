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
	void Start () {
        //VparentOffset = Parent.transform.position;
        VparentOffset = transform.position;
        Transform ChildTemp = transform;
        int IchildNumber = 0;
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

        VmaxPos = transform.position;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        

        if(transform.position.y < VmaxPos.y)
        {
            for (int i = 0; i < Childs.Count; i++)
            {
                float MovementMultiplier = (Childs.Count - i) / (float)Childs.Count;
                Childs[i].trans.position = Childs[i].positionOffset + (transform.position - VparentOffset) * MovementMultiplier;
            }
        } else
        {
            this.GetComponent<Rigidbody>().MovePosition(VmaxPos);
        }
	}
}
