using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffectMonitor : MonoBehaviour
{
    Timer monitorTimer;
    float speedupEffect;


    public bool SpeedupEffectIsActive
    {
        get { return monitorTimer.Running; }
    }

    public float SpeedupEffect
    {
        get { return speedupEffect; }
    }

    public float SpeedupSecondsLeft
    {
        get { return monitorTimer.GetSecondsLeft(); }
    }
    // Start is called before the first frame update
    void Start()
    {
        monitorTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedupEffectListener(SpeedupNewBall);

    }
    void SpeedupNewBall(float effectDuration, float speedupEffect)
    {
        if (!monitorTimer.Running)
        {
            monitorTimer.Duration = effectDuration;
            monitorTimer.Run();

            this.speedupEffect = speedupEffect;
        }
        else
        {
            monitorTimer.AddDuration(effectDuration);
        }


    }

    // Update is called once per frame
    void Update()
    {



    }
}
