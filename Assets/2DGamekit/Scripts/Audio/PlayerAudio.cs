using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerAudio : MonoBehaviour
{
    //private string surfaceOld;

    [Header("FMOD Events for player")]
    public EventReference footstepEvent;
    public EventReference jumpEvent;
    public EventReference fallEvent;
    public EventReference landEvent;
    public EventReference staffSwingEvent;
    public EventReference rangedPistolShotEvent;
    public EventReference painEvent;
    public EventReference deathEvent;

    // Event instances
    public EventInstance footstepInstance;
    public EventInstance jumpInstance;
    public EventInstance fallInstance;
    public EventInstance landInstance;
    public EventInstance staffSwingInstance;
    public EventInstance rangedPistolShotInstance;
    public EventInstance painInstance;
    public EventInstance deathInstance;

    // Game Object refs
    //public GameObject footstepAudioSource;
    //public GameObject staffSwingAudioSource;
    //public GameObject rangedPistolAudioSource;
    //public GameObject voiceAudioSource;

    // Variable for storing position of the game object
    private FMOD.ATTRIBUTES_3D attributes3d;

    // Start is called before the first frame update
    void Start()
    {
        // Instantiating FMOD events
        footstepInstance = RuntimeManager.CreateInstance(footstepEvent);
        jumpInstance = RuntimeManager.CreateInstance(jumpEvent);
        fallInstance = RuntimeManager.CreateInstance(fallEvent);
        landInstance = RuntimeManager.CreateInstance(landEvent);
        staffSwingInstance = RuntimeManager.CreateInstance(staffSwingEvent);
        rangedPistolShotInstance = RuntimeManager.CreateInstance(rangedPistolShotEvent);
        painInstance = RuntimeManager.CreateInstance(painEvent);
        deathInstance = RuntimeManager.CreateInstance(deathEvent);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the attributes3d with the current transform data.
        attributes3d = RuntimeUtils.To3DAttributes(transform);

        // Updating instance's position
        footstepInstance.set3DAttributes(attributes3d);
        jumpInstance.set3DAttributes(attributes3d);
        fallInstance.set3DAttributes(attributes3d);
        landInstance.set3DAttributes(attributes3d);
        staffSwingInstance.set3DAttributes(attributes3d);
        rangedPistolShotInstance.set3DAttributes(attributes3d);
        painInstance.set3DAttributes(attributes3d);
        deathInstance.set3DAttributes(attributes3d);
    }

    public void OnDisable()
    {
        StopSounds();
        ReleaseEvents();
    }

    public void OnDestroy()
    {
        StopSounds();
        ReleaseEvents();
    }

    public void StopSounds()
    {
        footstepInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        jumpInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        fallInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        landInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        staffSwingInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        rangedPistolShotInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        painInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        deathInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    private void ReleaseEvents()
    {
        footstepInstance.release();
        jumpInstance.release();
        fallInstance.release();
        landInstance.release();
        staffSwingInstance.release();
        rangedPistolShotInstance.release();
        painInstance.release();
        deathInstance.release();
    }

    /// <summary>
    /// Plays a footstep sound.
    /// </summary>
    public void PlayFootstep(TileBase surface = null)
    {
        // Checks what is the current surface and sets the global parameter
        if (surface != null)
        {
            string surfaceString = surface.ToString();

            if (surfaceString == "TilesetRockRules (UnityEngine.RuleTile)")
            {
                footstepInstance.setParameterByName("FloorType", 0f);
            }
            else
            {
                footstepInstance.setParameterByName("FloorType", 1f);
            }
        }

        footstepInstance.start();
    }

    /// <summary>
    /// Plays the jump sound.
    /// </summary>
    public void PlayJump()
    {
        jumpInstance.start();
    }

    public void PlayFall()
    {
        fallInstance.start();
    }

    /// <summary>
    /// Plays the landing sound.
    /// </summary>
    public void PlayLand(TileBase surface = null)
    {
        // Checks what is the current surface and sets the global parameter
        if (surface != null)
        {
            string surfaceString = surface.ToString();

            if (surfaceString == "TilesetRockRules (UnityEngine.RuleTile)")
            {
                landInstance.setParameterByName("FloorType", 0f);
            }
            else
            {
                landInstance.setParameterByName("FloorType", 1f);
            }
        }

        landInstance.start();
    }

    /// <summary>
    /// Plays the attack sound.
    /// </summary>
    public void PlayStaffSwing()
    {
        staffSwingInstance.start();
    }

    /// <summary>
    /// Plays the attack sound.
    /// </summary>
    public void PlayRangedPistolShot()
    {
        rangedPistolShotInstance.start();
    }

    /// <summary>
    /// Plays the pain sound.
    /// </summary>
    public void PlayPain()
    {
        painInstance.start();
    }

    /// <summary>
    /// Plays the death sound.
    /// </summary>
    public void PlayDeath()
    {
        deathInstance.start();
    }
}