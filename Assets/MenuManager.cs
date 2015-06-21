using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public GameObject PauseMenu;
    bool BisPaused = false;

    void Awake()
    {
        PauseMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            if(!BisPaused)
            {
                Pause();
            } else
            {
                UnPause();
            }
        }
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        BisPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        PauseMenu.SetActive(false);
        BisPaused = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
