using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 5;
    static float ballLifeTime = 10;
    static float minSpawningTime = 5;
    static float maxSpawningTime = 10;
    static int standardBlockPoints = 1;
    static int bonusBlockPoints = 5;
    static int pickupBlockPoints = 10;
    static float standardBlockProbabilities = 0.7f;
    static float bonusBlockProbabilities = 0.2f;
    static float freezerBlockProbabilities = 0.05f;
    static float speedupBlockProbabilities = 0.05f;
    static int amountOfBallsPerGame = 10;
    static float freezerEffectDuration = 2;
    static float speedupEffectDuration = 2;
    static float speedupEffect = 1.5f;
    static float initiaBallPositionX = 0;
    static float initiaBallPositionY = 0;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    public float BallLifeTime
    {
        get { return ballLifeTime; }
    }

    public float MinSpawningTime
    {
        get { return minSpawningTime; }
    }
    public float MaxSpawningTime
    {
        get { return maxSpawningTime; }
    }
    public int StandardBlockPoints
    {
        get { return standardBlockPoints; }
    }
    public int BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }
    public int PickupBlockPoints
    {
        get { return pickupBlockPoints; }
    }
    public float StandardBlockProbabilities
    {
        get { return standardBlockProbabilities; }
    }
    public float BonusBlockProbabilities
    {
        get { return bonusBlockProbabilities; }
    }
    public float FreezerBlockProbabilities
    {
        get { return freezerBlockProbabilities; }
    }
    public float SpeedupBlockProbabilities
    {
        get { return speedupBlockProbabilities; }
    }
    public int AmountOfBallsPerGame
    {
        get { return amountOfBallsPerGame; }
    }

    public float FreezerEffectDuration
    {
        get { return freezerEffectDuration; }
    }
    public float SpeedupEffectDuration
    {
        get { return speedupEffectDuration; }
    }
    public float SpeedupEffect
    {
        get { return speedupEffect; }
    }
    public float InitiaBallPositionX
    {
        get { return initiaBallPositionX; }
    }
    public float InitiaBallPositionY
    {
        get { return initiaBallPositionY; }
    }
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader reader = null;
        try
        {
            reader = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            string names = reader.ReadLine();
            string values = reader.ReadLine();
            SetConfigurationDataFields(values);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (reader!=null)
            {
                reader.Close();
            }
        }
        
    }

    void SetConfigurationDataFields (string csvValues)
    {
        string[] values = csvValues.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(values[0]);
        ballImpulseForce = float.Parse(values[1]);
        ballLifeTime = float.Parse(values[2]);
        minSpawningTime = float.Parse(values[3]);
        maxSpawningTime = float.Parse(values[4]);
        standardBlockPoints = int.Parse(values[5]);
        bonusBlockPoints = int.Parse(values[6]);
        pickupBlockPoints = int.Parse(values[7]);
        standardBlockProbabilities = float.Parse(values[8]);
        bonusBlockProbabilities = float.Parse(values[9]);
        freezerBlockProbabilities = float.Parse(values[10]);
        speedupBlockProbabilities = float.Parse(values[11]);
        amountOfBallsPerGame = int.Parse(values[12]);
        freezerEffectDuration = float.Parse(values[13]);
        speedupEffectDuration = float.Parse(values[14]);
        speedupEffect = float.Parse(values[15]);
        initiaBallPositionX = float.Parse(values[16]);
        initiaBallPositionY = float.Parse(values[17]);
    }

    #endregion
}
