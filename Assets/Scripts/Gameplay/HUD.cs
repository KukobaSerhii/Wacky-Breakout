using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HUD : MonoBehaviour
{
    Text score;
    int scoreValue;
    public int ScoreValue
    {
        get { return scoreValue; }
    }
    const string ScorePrefix = "Score : ";

    Text ballsLeft;
    int amountOfBalls;
    const string BallsPrefix = "Balls left : ";
    BallsReserveIsEmpty ballsReserveIsEmpty;


    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        score.text = ScorePrefix + scoreValue.ToString();
        ballsLeft = GameObject.FindGameObjectWithTag("BallsLeft").GetComponent<Text>();
        amountOfBalls = ConfigurationUtils.AmountOfBallsPerGame;
        ballsLeft.text = BallsPrefix + amountOfBalls.ToString();
        EventManager.AddPointsAddedListener(AddScore);
        EventManager.AddBallsReserveWasDecreasedListener(DecreaseBallsReserve);
        ballsReserveIsEmpty = new BallsReserveIsEmpty();
        EventManager.AddBallsReserveIsEmptyInvoker(this);

    }
    public void AddBallsReserveIsEmptyListener(UnityAction handler)
    {
        ballsReserveIsEmpty.AddListener(handler);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AddScore(int value)
    {
        scoreValue += value;
        score.text = ScorePrefix + scoreValue.ToString();
    }
    void DecreaseBallsReserve()
    {
        amountOfBalls--;
        if (amountOfBalls == 0)
        {
            ballsReserveIsEmpty.Invoke();
            AudioManager.Play(AudioClipName.GameLost);
        }
        ballsLeft.text = BallsPrefix + amountOfBalls.ToString();
    }
}
