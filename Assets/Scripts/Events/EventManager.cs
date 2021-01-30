using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager 
{
    static List<PickupBlock> freezerEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float>> freezerEffectListeners = new List<UnityAction<float>>();
    static List<PickupBlock> speedupEffectInvokers = new List<PickupBlock>();
    static List<UnityAction<float,float>> speedupEffectListeners = new List<UnityAction<float,float>>();
    static List<Block> pointsAddedInvokers = new List<Block>();
    static List<UnityAction<int>> pointsAddedListeners = new List<UnityAction<int>>();
    static List<Ball> ballsReserveWasDecreasedInvokers = new List<Ball>();
    static List<UnityAction> ballsReserveWasDecreasedListeners = new List<UnityAction>();
    static List<Ball> ballDiedInvokers = new List<Ball>();
    static List<UnityAction> ballDiedListeners = new List<UnityAction>();
    static HUD ballsReserveIsEmptyInvoker;
    static List<UnityAction> ballsReserveIsEmptyListeners = new List<UnityAction>();
    public static void AddBallsReserveIsEmptyInvoker (HUD invoker)
    {
        ballsReserveIsEmptyInvoker = invoker;
        foreach (UnityAction listener in ballsReserveIsEmptyListeners)
        {
            ballsReserveIsEmptyInvoker.AddBallsReserveIsEmptyListener(listener);
        }
    }
    public static void AddBallsReserveIsEmptyListener(UnityAction handler)
    {
        ballsReserveIsEmptyListeners.Add(handler);
        if (ballsReserveIsEmptyInvoker!=null)
        {
            ballsReserveIsEmptyInvoker.AddBallsReserveIsEmptyListener(handler);
        }
    }


    public static void AddFreezerEffectInvoker(PickupBlock invoker)
    {
        freezerEffectInvokers.Add(invoker);
        foreach (UnityAction<float> listener in freezerEffectListeners)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }
    public static void AddSpeedupEffectInvoker(PickupBlock invoker)
    {
        speedupEffectInvokers.Add(invoker);
        foreach (UnityAction<float,float> listener in speedupEffectListeners)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }

    public static void AddFreezerEffectListener(UnityAction<float> handler)
    {
        freezerEffectListeners.Add(handler);
        foreach (PickupBlock invoker in freezerEffectInvokers)
        {
            invoker.AddFreezerEffectListener(handler);
        }
    }
    public static void AddSpeedupEffectListener(UnityAction<float, float> handler)
    {
        speedupEffectListeners.Add(handler);
        foreach (PickupBlock invoker in speedupEffectInvokers)
        {
            invoker.AddSpeedupEffectListener(handler);
        }
    }
    public static void AddPointsAddedInvoker(Block invoker)
    {
        pointsAddedInvokers.Add(invoker);
        foreach (UnityAction<int> listener in pointsAddedListeners)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }

    public static void AddPointsAddedListener(UnityAction<int> handler)
    {
        pointsAddedListeners.Add(handler);
        foreach (Block invoker in pointsAddedInvokers)
        {
            invoker.AddPointsAddedListener(handler);
        }
    }
    public static void AddBallsReserveWasDecreasedInvoker(Ball invoker)
    {
        ballsReserveWasDecreasedInvokers.Add(invoker);
        foreach  (UnityAction listener in ballsReserveWasDecreasedListeners)
        {
            invoker.AddBallsReserveWasDecreasedListener(listener);
        }
    }
    public static void AddBallsReserveWasDecreasedListener(UnityAction handler)
    {
        ballsReserveWasDecreasedListeners.Add(handler);
        foreach (Ball invoker in ballsReserveWasDecreasedInvokers)
        {
            invoker.AddBallsReserveWasDecreasedListener(handler);
        }
    }
    public static void AddBallDiedInvoker(Ball invoker)
    {
        ballDiedInvokers.Add(invoker);
        foreach (UnityAction listener in ballDiedListeners)
        {
            invoker.AddBallDiedListener(listener);

        }
    }
    public static void AddBallDiedListener(UnityAction handler)
    {
        ballDiedListeners.Add(handler);
        foreach (Ball invoker in ballDiedInvokers)
        {
            invoker.AddBallDiedListener(handler);
        }
    }
}
