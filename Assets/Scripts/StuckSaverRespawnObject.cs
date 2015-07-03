using UnityEngine;
using System.Collections;

public class StuckSaverRespawnObject : MonoBehaviour {

    public GameObject GsaveTarget;
    public GameObject GspawnPrefab;
    public Animator FeedbackText;

    Vector3 originalPos;
    Quaternion orignalRot;

	// Use this for initialization
	void Start () {

        originalPos = GsaveTarget.transform.position;
        orignalRot = GsaveTarget.transform.rotation;
	
	}
	
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GsaveTarget)
        {
            GameObject NewSaveTarget = Instantiate(GspawnPrefab, originalPos, orignalRot) as GameObject;
            FeedbackText.SetTrigger("Fail");
            Destroy(GsaveTarget);
            GsaveTarget = NewSaveTarget;
        }
    }
}
