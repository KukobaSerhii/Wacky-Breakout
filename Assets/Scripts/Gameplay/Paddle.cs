using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D rb2d;
    BoxCollider2D boxCollider;
    float boxColliderWidth;
    float boxColliderHeight;
    Vector2 newPosition;
    Vector2 initialPosition = new Vector2(0, -4.5f);
    const float BounceAngleHalfRange = 60 * Mathf.Deg2Rad;
    bool paddleIsFrozen = false;
    Timer freezTimer;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        boxColliderWidth = boxCollider.size.x;
        boxColliderHeight = boxCollider.size.y;
        transform.position = initialPosition;
        freezTimer = gameObject.AddComponent<Timer>();
        freezTimer.AddTimerFinishedListener(HandleFreezTimerFinished);
        EventManager.AddFreezerEffectListener(FreezPaddle);


    }

    // Update is called once per frame
    void Update()
    {
        
      


    }

    float CalculateClampedX()
    {

        if ((newPosition.x - boxColliderWidth / 2) < ScreenUtils.ScreenLeft)
        {

            newPosition.x = ScreenUtils.ScreenLeft + boxColliderWidth / 2;

            return newPosition.x;

        }
        if ((newPosition.x + boxColliderWidth / 2) > ScreenUtils.ScreenRight)
        {

            newPosition.x = ScreenUtils.ScreenRight - boxColliderWidth / 2;
            return newPosition.x;

        }
        return newPosition.x;
    }
    //jvkvlyuhun;
    void OnCollisionEnter2D(Collision2D coll)
    {
        float halfColliderWidth = boxColliderWidth / 2;
        float halfColliderHeight = boxColliderHeight / 2;
        if (coll.gameObject.CompareTag("Ball") && TopCollision(coll))
        {
            AudioManager.Play(AudioClipName.BallCollision);
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x - coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter / halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }
    bool TopCollision(Collision2D coll)
    {
        const float tolerance = 0.05f;

        // on top collisions, both contact points are at the same y location
        ContactPoint2D[] contacts = coll.contacts;
        return Mathf.Abs(contacts[0].point.y - contacts[1].point.y) < tolerance;
    }

    //kjkjnfvjnfmv
    private void FixedUpdate()
    {
        newPosition = gameObject.transform.position;
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0 && !paddleIsFrozen)
        {

            newPosition.x += ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.fixedDeltaTime* horizontalInput;


        }
       


        newPosition.x = CalculateClampedX();
        rb2d.MovePosition(newPosition);
    }
    void FreezPaddle(float seconds)
    {
        if (freezTimer.Running)
        {
            freezTimer.AddDuration(seconds);
        }
        else
        {
            paddleIsFrozen = true;
            freezTimer.Duration = seconds;
            freezTimer.Run();
        }
    }
    void HandleFreezTimerFinished()
    {
        AudioManager.Play(AudioClipName.FreezerEffectDeactivated);
        paddleIsFrozen = false;
    }
}
