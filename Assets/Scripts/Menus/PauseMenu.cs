using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        
    }
    public void ResumeButtonOnClickEventHandler()
    {
        Time.timeScale = 1;
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Destroy(gameObject);
        
    }
    public void QuitButtonOnClickEventHandler()
    {
        Time.timeScale = 1;
        MenuManager.GoToMenu(MenuName.Main);
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Destroy(gameObject);
    }
}
