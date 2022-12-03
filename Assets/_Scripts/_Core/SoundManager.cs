using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The available game sounds.
/// </summary>
public enum GameSounds
{
    Countdown,
    Supernova,
    NANI,
    GOKU,
}

/*
 * [CLASS DOCUMENTATION]
 * 
 * THIS CLASS HAS A SINGLETON
 * 
 * Inspector variables: These variables must be set from the inspector.
 * Private variables: These variables are changed in runtime.
 * 
 * [Class flow]
 * This script has a single public method than can be used to play a passed SFX as OneShot.
 */
public class SoundManager : MonoBehaviour
{
    public static SoundManager S;

    [Header("Set in inspector")]
    [SerializeField] List<AudioClip> audioClips;

    //Private variables
    AudioSource mainAudioSource;

    private void Awake()
    {
        if (S == null || S != this)
        {
            S = this;
        }

        mainAudioSource = GetComponent<AudioSource>();
    }

    public void PlayOneShotAudio(GameSounds clipIndex, float volumeMultiplier)
    {
        mainAudioSource.PlayOneShot(audioClips[(int)clipIndex], volumeMultiplier);
    }

    private void OnDestroy()
    {
        S = null;
    }
}
