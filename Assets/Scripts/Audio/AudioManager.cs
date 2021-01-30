using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager 
{
    static AudioSource audioSource;
    static bool initialized = false;
    static Dictionary<AudioClipName, AudioClip> audioclips = new Dictionary<AudioClipName, AudioClip>();
    public static bool Initialized
    {
        get { return initialized; }
    }
    public static void Initialize(AudioSource source)
    {
        audioSource = source;
        initialized = true;
        audioclips.Add(AudioClipName.BallCollision, Resources.Load<AudioClip>("BallCollision"));
        audioclips.Add(AudioClipName.BallLost,Resources.Load<AudioClip>("BallLost"));
        audioclips.Add(AudioClipName.BallSpawn, Resources.Load<AudioClip>("BallSpawn"));
        audioclips.Add(AudioClipName.FreezerEffectActivated, Resources.Load<AudioClip>("FreezerEffectActivated"));
        audioclips.Add(AudioClipName.FreezerEffectDeactivated, Resources.Load<AudioClip>("FreezerEffectDeactivated"));
        audioclips.Add(AudioClipName.GameLost, Resources.Load<AudioClip>("GameLost"));
        audioclips.Add(AudioClipName.MenuButtonClick, Resources.Load<AudioClip>("MenuButtonClick"));
        audioclips.Add(AudioClipName.SpeedupEffectActivated, Resources.Load<AudioClip>("SpeedupEffectActivated"));
        audioclips.Add(AudioClipName.SpeedupEffectDeactivated, Resources.Load<AudioClip>("SpeedupEffectDeactivated"));
        
    }
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioclips[name]);
    }
}
