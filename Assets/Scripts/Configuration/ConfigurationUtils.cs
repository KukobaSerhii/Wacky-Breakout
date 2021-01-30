using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static ConfigurationData configurationData;
    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }
    public static float BallImpulseForce
    {
        get { return configurationData.BallImpulseForce; }
    }

    public static float BallLifeTime
    {
        get { return configurationData.BallLifeTime; }
    }

    public static float MinSpawningTime
    {
        get { return configurationData.MinSpawningTime; }
    }

    public static float MaxSpawningTime
    {
        get { return configurationData.MaxSpawningTime; }
    }
    public static int StandardBlockPoints
    {
        get { return configurationData.StandardBlockPoints; }
    }

    public static int BonusBlockPoints
    {
        get { return configurationData.BonusBlockPoints; }
    }
    public static int PickupBlockPoints
    {
        get { return configurationData.PickupBlockPoints; }
    }
    public static float StandardBlockProbabilities
    {
        get { return configurationData.StandardBlockProbabilities; }
    }
    public static float BonusBlockProbabilities
    {
        get { return configurationData.BonusBlockProbabilities; }
    }
    public static float FreezerBlockProbabilities
    {
        get { return configurationData.FreezerBlockProbabilities; }
    }
    public static float SpeedupBlockProbabilities
    {
        get { return configurationData.SpeedupBlockProbabilities; }
    }
    public static int AmountOfBallsPerGame
    {
        get { return configurationData.AmountOfBallsPerGame; }
    }
    public static float FreezerEffectDuration
    {
        get { return configurationData.FreezerEffectDuration; }
    }
    public static float SpeedupEffectDuration
    {
        get { return configurationData.SpeedupEffectDuration; }
    }
    public static float SpeedupEffect
    {
        get { return configurationData.SpeedupEffect; }
    }
    public static float InitiaBallPositionX
    {
        get { return configurationData.InitiaBallPositionX; }
    }
    public static float InitiaBallPositionY
    {
        get { return configurationData.InitiaBallPositionY; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();


    }
}
