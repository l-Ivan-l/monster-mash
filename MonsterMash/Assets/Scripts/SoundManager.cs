using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource musicMaster;
    public AudioSource audioEffectsMaster;
    public AudioSource characterEffectsMaster;
    public AudioSource ambienceEffectsMaster;
    public AudioSource uxEffectsMaster;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundEffect(AudioClip audioClip, float volume)
    {
        audioEffectsMaster.PlayOneShot(audioClip, volume);
    }

    public void PlayCharacterSoundEffect(AudioClip audioClip, float volume)
    {
        characterEffectsMaster.PlayOneShot(audioClip, volume);
    }

    public void PlayAmbienceSoundEffect(AudioClip audioClip, float volume)
    {
        ambienceEffectsMaster.PlayOneShot(audioClip, volume);
    }

    public void PlayUXSoundEffect(AudioClip audioClip, float volume)
    {
        uxEffectsMaster.PlayOneShot(audioClip, volume);
    }
}