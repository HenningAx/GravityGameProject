using UnityEngine;
using System.Collections;

public class ToolboxAudio : MonoBehaviour {

    public AudioSource[] FallingSound;
    public GameObject Toolbox;

    private int clipNum;
    private float volumMult;
   

    void Awake()
    {
        

    }



   
    void Update(){

        clipNum = Random.Range(0, FallingSound.Length);
        
        
       
     
    }
    void OnCollisionEnter(Collision col)
    {
       // if (col.gameObject.GetComponent<MeshRenderer>().material == )
        if(col.gameObject.tag == "Wand" )
        {
           volumMult = col.relativeVelocity.magnitude * 1/20;

            FallingSound[clipNum].Play();
            FallingSound[clipNum].volume = volumMult;
            
            
        }

    }
}
