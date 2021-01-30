using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    Timer deathTimer;
    Timer delayTimer;
    Timer speedupTimer;
    const float delaySeconds = 1f;
    Rigidbody2D rb2d;
    Vector2 direction;
    float angle = 268;
    bool forceWasAdded = false;
    bool ballspeedWasIncreased = false;
    BoxCollider2D boxCollider2d;
    float boxCollider2DHalfHeight;
    float boxCollider2DHalfWidth;

    float speedupEffect;
    Vector2 initialBallposition;
    float initialSpeedMagnitude;
    BallsReserveWasDecreased ballsReserveWasDecreased;
    BallDied ballDied;


    // Start is called before the first frame update
    void Start()
    {
        initialBallposition = new Vector2(ConfigurationUtils.InitiaBallPositionX, ConfigurationUtils.InitiaBallPositionY);
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2d = gameObject.GetComponent<BoxCollider2D>();
        boxCollider2DHalfHeight = boxCollider2d.size.y / 2;
        boxCollider2DHalfWidth = boxCollider2d.size.x / 2;

        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.AddTimerFinishedListener(HandleDeathTimerFinished);
        deathTimer.Duration = ConfigurationUtils.BallLifeTime;
        ballDied = new BallDied();

        delayTimer = gameObject.AddComponent<Timer>();
        delayTimer.AddTimerFinishedListener(HandleDelayTimerFinished);
        delayTimer.Duration = delaySeconds;
        delayTimer.Run();

        speedupTimer = gameObject.AddComponent<Timer>();
        speedupTimer.AddTimerFinishedListener(HandleSpeedupTimerFinished);



        EventManager.AddSpeedupEffectListener(Speedup);
        ballsReserveWasDecreased = new BallsReserveWasDecreased();
        EventManager.AddBallsReserveWasDecreasedInvoker(this);
        EventManager.AddBallDiedInvoker(this);
    }
    public void AddBallDiedListener(UnityAction handler)
    {
        ballDied.AddListener(handler);
    }
    void HandleDelayTimerFinished()
    {
        MakeBallMove();
        deathTimer.Run();
    }
    void HandleDeathTimerFinished()
    {
        ballDied.Invoke();
        Destroy(gameObject);
    }
    void HandleSpeedupTimerFinished()
    {
        rb2d.velocity /= speedupEffect;
        AudioManager.Play(AudioClipName.SpeedupEffectDeactivated);

    }
    public void AddBallsReserveWasDecreasedListener(UnityAction handler)
    {
        ballsReserveWasDecreased.AddListener(handler);
    }
    public void SetDirection(Vector2 direction)
    {

        rb2d.velocity = rb2d.velocity.magnitude * direction;
    }

    // Update is called once per frame
    void Update()
    {

        if (!EffectUtils.SpeedupEffectIsActive && ballspeedWasIncreased)
        {
            rb2d.velocity /= EffectUtils.SpeedupEffect;
            ballspeedWasIncreased = false;
            
        }
        if (forceWasAdded && rb2d.velocity.magnitude < initialSpeedMagnitude * 0.8)
        {
            Destroy(gameObject);
        }


    }
    void MakeBallMove()
    {


        direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        if (gameObject.transform.position.x == initialBallposition.x && gameObject.transform.position.y == initialBallposition.y)
        {
            rb2d.AddForce(direction * ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
            forceWasAdded = true;
            initialSpeedMagnitude = rb2d.velocity.magnitude;
        }
        else
        {
            Destroy(gameObject);
        }

        if (EffectUtils.SpeedupEffectIsActive)
        {
            rb2d.velocity *= EffectUtils.SpeedupEffect;
            ballspeedWasIncreased = true;

        }


    }
    private void OnBecameInvisible()
    {


        if ((gameObject.transform.position.y + boxCollider2DHalfHeight) < ScreenUtils.ScreenBottom)
        {
            AudioManager.Play(AudioClipName.BallLost);
            ballDied.Invoke();
            ballsReserveWasDecreased.Invoke();
            Destroy(gameObject);


        }

    }
    void Speedup(float effectDuration, float speedupEffect)
    {
        if (!speedupTimer.Running)
        {

            this.speedupEffect = speedupEffect;
            speedupTimer.Duration = effectDuration;
            speedupTimer.Run();
            rb2d.velocity *= speedupEffect;
            ballspeedWasIncreased = true;

        }
        else
        {
            speedupTimer.AddDuration(effectDuration);
        }


    }
}
