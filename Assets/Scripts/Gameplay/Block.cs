using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    protected int blockPoints;
   
    PointsAdded pointsAdded;
    // Start is called before the first frame update
    protected virtual void Start()
    {
       
        pointsAdded = new PointsAdded();
        EventManager.AddPointsAddedInvoker(this);
    }
    public void AddPointsAddedListener(UnityAction<int> handler)
    {
        pointsAdded.AddListener(handler);
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {

            AudioManager.Play(AudioClipName.BallCollision);
            pointsAdded.Invoke(blockPoints);
            Destroy(gameObject);

        }
    }
}
