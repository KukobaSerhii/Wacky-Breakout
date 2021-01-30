using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block
{
    [SerializeField]
    Sprite freezerblock;
    [SerializeField]
    Sprite speedupblock;
    PickupEffect pickupEffect;
    float effectDuration;
    float speedupEffect;
    FreezerEffectActivated freezerEffectActivated;
    SpeedupEffectActivated speedupEffectActivated;
    public PickupEffect PickupEffect
    {
        set
        {
            pickupEffect = value;

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();


            if (pickupEffect == PickupEffect.Freezer)
            {
                spriteRenderer.sprite = freezerblock;
                effectDuration = ConfigurationUtils.FreezerEffectDuration;
                freezerEffectActivated = new FreezerEffectActivated();
                EventManager.AddFreezerEffectInvoker(this);
            }
            else
            {
                spriteRenderer.sprite = speedupblock;
                effectDuration = ConfigurationUtils.SpeedupEffectDuration;
                speedupEffect = ConfigurationUtils.SpeedupEffect;
                speedupEffectActivated = new SpeedupEffectActivated();
                EventManager.AddSpeedupEffectInvoker(this);

            }

        }
    }
    public void AddFreezerEffectListener(UnityAction<float> handler)
    {
        freezerEffectActivated.AddListener(handler);
    }
    public void AddSpeedupEffectListener(UnityAction<float, float> handler)
    {
        speedupEffectActivated.AddListener(handler);
    }
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (pickupEffect == PickupEffect.Freezer)
            {
                AudioManager.Play(AudioClipName.FreezerEffectActivated);
                freezerEffectActivated?.Invoke(effectDuration);

            }
            else if (pickupEffect == PickupEffect.Speedup)
            {
                AudioManager.Play(AudioClipName.SpeedupEffectActivated);
                speedupEffectActivated?.Invoke(effectDuration, speedupEffect);
                
            }
            
            base.OnCollisionEnter2D(collision);
            
        }
        
    }

    // Start is called before the first frame update
    protected override void Start()
    {

        blockPoints = ConfigurationUtils.PickupBlockPoints;
        base.Start();


    }

    // Update is called once per frame
    void Update()
    {

    }
}
