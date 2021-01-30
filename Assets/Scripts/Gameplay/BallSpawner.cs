using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;
    Vector2 initialBallposition;
    Vector2 lowerLeftCornerOfBallCollider;
    Vector2 upperRightCornerOfBallCollider;
    Timer spawningTimer;







    // Start is called before the first frame update
    void Start()
    {
        initialBallposition = new Vector2(ConfigurationUtils.InitiaBallPositionX, ConfigurationUtils.InitiaBallPositionY);
        spawningTimer = gameObject.AddComponent<Timer>();
        spawningTimer.AddTimerFinishedListener(HandleSpawningTimerFinished);
        spawningTimer.Duration = Random.Range(ConfigurationUtils.MinSpawningTime, ConfigurationUtils.MaxSpawningTime);
        spawningTimer.Run();
        GameObject firstBall = Instantiate(ballPrefab, initialBallposition, Quaternion.identity);
        BoxCollider2D bc2d = firstBall.GetComponent<BoxCollider2D>();
        lowerLeftCornerOfBallCollider = new Vector2(initialBallposition.x - bc2d.size.x / 2, initialBallposition.y - bc2d.size.y / 2);
        upperRightCornerOfBallCollider = new Vector2(initialBallposition.x + bc2d.size.x / 2, initialBallposition.y + bc2d.size.y / 2);
        EventManager.AddBallDiedListener(HandleBallDied);
        EventManager.AddBallsReserveIsEmptyListener(HandleBallsReserveIsEmpty);




    }
    void HandleBallsReserveIsEmpty()
    {

        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);

        }
        Destroy(GameObject.FindGameObjectWithTag("Paddle"));
    }

    // Update is called once per frame
    void Update()
    {


    }
    void HandleBallDied()
    {

        SpawnBall();

    }
    void HandleSpawningTimerFinished()
    {


        SpawnBall();

    }

    void SpawnBall()
    {
        if (Physics2D.OverlapArea(lowerLeftCornerOfBallCollider, upperRightCornerOfBallCollider) == null)
        {
            GameObject newBall = Instantiate(ballPrefab, initialBallposition, Quaternion.identity);
            AudioManager.Play(AudioClipName.BallSpawn);
            spawningTimer.Duration = Random.Range(ConfigurationUtils.MinSpawningTime, ConfigurationUtils.MaxSpawningTime);
            spawningTimer.Run();
        }
    }
}
