/* A script for a loading bar that shows the process of loading a scene
 * */


using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingBar : MonoBehaviour {

    AsyncOperation async = null;
    RectTransform progressBarTrans;
    float progressBarFullX;
    float deltaX;

    void Start()
    {
        progressBarTrans = this.GetComponent<RectTransform>();
        progressBarFullX = progressBarTrans.sizeDelta.x;
        progressBarTrans.sizeDelta = new Vector2(-1920, progressBarTrans.sizeDelta.y);
        deltaX = progressBarFullX + 1920;
    }

    void Update()
    {
        if(async != null)
        {
            progressBarTrans.sizeDelta = new Vector2(-1920 + deltaX * async.progress, progressBarTrans.sizeDelta.y);
        }
    }

    public void StartLoadLevel(int level)
    {
        StartCoroutine(LoadLevel(level));
    }

    public IEnumerator LoadLevel(int levelID)
    {
        async = Application.LoadLevelAsync(levelID);
        yield return async;
    }
}
