using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    Text score;
    HUD script;

    const string Prefix = "Game Over!\n" + "You scored: ";

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        score.text = Prefix;
        script = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        score.text += script.ScoreValue;
    } 
    
    public void HandleQuitButtonClickEvent()
    {
        Time.timeScale = 1;
        MenuManager.GoToMenu(MenuName.Main);
        Destroy(gameObject);
        AudioManager.Play(AudioClipName.MenuButtonClick);
    }

   

}
