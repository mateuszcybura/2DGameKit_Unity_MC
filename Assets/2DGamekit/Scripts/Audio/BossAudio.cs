using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class BossAudio : MonoBehaviour
{
    [Header("FMOD Events for boss")]
    public EventReference gunnerStepEvent;
    public EventReference gunnerIdleEvent;
    [Space]
    public EventReference gunnerLaserAttackEvent;
    public EventReference gunnerGrenadeThrowEvent;
    public EventReference gunnerLightningAttackEvent;
    public EventReference gunnerAttackChargeEvent;
    [Space]
    public EventReference gunnerLaserHitEvent;
    [Space]
    public EventReference gunnerGettingUpEvent;
    public EventReference gunnerHurtEvent;
    public EventReference gunnerDeathEvent;
    public EventReference gunnerDeathBeamEvent;
    public EventReference gunnerSparksEvent;
    [Space]
    public EventReference gunnerShieldActivateLp;
    public EventReference gunnerShieldHit;
    public EventReference gunnerShieldDeactivate;

    [Header("FMOD Studio Event Emmiter References")]
    public StudioEventEmitter gunnerStepEmitter;
    public StudioEventEmitter gunnerIdleEmitter;
    [Space]
    public StudioEventEmitter gunnerLaserAttackEmitter;
    public StudioEventEmitter gunnerGrenadeThrowEmitter;
    public StudioEventEmitter gunnerLightningAttackEmitter;
    public StudioEventEmitter gunnerAttackChargeEmitter;
    [Space]
    public StudioEventEmitter gunnerLaserHitEmitter;
    [Space]
    public StudioEventEmitter gunnerGettingUpEmitter;
    public StudioEventEmitter gunnerHurtEmitter;
    public StudioEventEmitter gunnerDeathEmitter;
    public StudioEventEmitter gunnerDeathBeamEmitter;
    public StudioEventEmitter gunnerSparksEmitter;
    [Space]
    public StudioEventEmitter gunnerShieldActivateLpEmitter;
    public StudioEventEmitter gunnerShieldHitEmitter;
    public StudioEventEmitter gunnerShieldDeactivateEmitter;

    // Start is called before the first frame update
    void Start()
    {
        // Referencing the Events to the Studio Event Emitters
        gunnerStepEmitter.EventReference = gunnerStepEvent;
        gunnerIdleEmitter.EventReference = gunnerIdleEvent;

        gunnerLaserAttackEmitter.EventReference = gunnerLaserAttackEvent;
        gunnerGrenadeThrowEmitter.EventReference = gunnerGrenadeThrowEvent;
        gunnerLightningAttackEmitter.EventReference = gunnerLightningAttackEvent;
        gunnerAttackChargeEmitter.EventReference = gunnerAttackChargeEvent;

        gunnerLaserHitEmitter.EventReference = gunnerLaserHitEvent;

        gunnerGettingUpEmitter.EventReference = gunnerGettingUpEvent;
        gunnerHurtEmitter.EventReference = gunnerHurtEvent;
        gunnerDeathEmitter.EventReference = gunnerDeathEvent;
        gunnerDeathBeamEmitter.EventReference = gunnerDeathBeamEvent;
        gunnerSparksEmitter.EventReference = gunnerSparksEvent;

        gunnerShieldActivateLpEmitter.EventReference = gunnerShieldActivateLp;
        gunnerShieldHitEmitter.EventReference = gunnerShieldHit;
        gunnerShieldDeactivateEmitter.EventReference = gunnerShieldDeactivate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFMODEvent(StudioEventEmitter eventEmitter)
    {
        eventEmitter.Play();
    }
    
    public void SetBossShieldParameter(float shieldVal)
    {
        RuntimeManager.StudioSystem.setParameterByName("Boss_Shield", shieldVal);
    }

    public void SetBossHealthParameter(float healthVal)
    {
        RuntimeManager.StudioSystem.setParameterByName("Boss_Health", healthVal);
    }

    public void SetBossRoundParameter(float roundNum)
    {
        RuntimeManager.StudioSystem.setParameterByName("Boss_Round", roundNum);
    }
}
