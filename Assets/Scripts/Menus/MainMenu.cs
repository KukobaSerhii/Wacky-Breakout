using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void QuitButtonOnClickEventHandler()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Application.Quit();
        
    }
    public void HelpButtonOnClickEventHandler()
    {
        MenuManager.GoToMenu(MenuName.Help);
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }
    public void PlayButtonOnClickEventHandler()
    {
        SceneManager.LoadScene("GamePlay");
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }
}
