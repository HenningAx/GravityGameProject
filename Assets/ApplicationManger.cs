using UnityEngine;
using System.Collections;

public class ApplicationManger : MonoBehaviour {

    public void LoadLevel(int level)
    {
        Application.LoadLevel(level);
    }

    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
