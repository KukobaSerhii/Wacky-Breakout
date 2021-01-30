using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectUtils 
{
    
    public static bool SpeedupEffectIsActive
    {
        get { return GetSpeedupEffectMonitor().SpeedupEffectIsActive; }
    }
    public static float SpeedupEffect
    {
        get { return GetSpeedupEffectMonitor().SpeedupEffect; }
    }
    public static float SpeedupSecondsLeft
    {
        get { return GetSpeedupEffectMonitor().SpeedupSecondsLeft; }
    }
       
    static SpeedupEffectMonitor GetSpeedupEffectMonitor()
    {
        return Camera.main.GetComponent<SpeedupEffectMonitor>();
    }
}
