using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WackyBreakout : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddBallsReserveIsEmptyListener(HandleBallsReserveIsEmpty);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GoToMenu(MenuName.Paus);
        }
    }
    public void HandleBallsReserveIsEmpty()
    {
        Instantiate(Resources.Load("GameOver"));
    }
}
