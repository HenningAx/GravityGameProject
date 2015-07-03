using UnityEngine;
using System.Collections;

public class MoviePlay : MonoBehaviour {

    public GameObject Screen;
    MovieTexture movie;
    Material ScreenMat;
    bool BwasPlayed = false;

    void Awake()
    {
        ScreenMat = Screen.GetComponent<MeshRenderer>().material;
        movie = ScreenMat.mainTexture as MovieTexture;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !BwasPlayed)
        {
            BwasPlayed = true;
            StartCoroutine(playMovie(15.0f));
        }
    }

    IEnumerator playMovie(float delay)
    {
        movie.Play();
        yield return new WaitForSeconds(delay);
        movie.Stop();
        ScreenMat.SetColor("_MainColor", Color.black);
        ScreenMat.SetColor("_EmissionColor", Color.black);
    }

    

}
