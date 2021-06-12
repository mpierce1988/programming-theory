using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffects : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField]
    private AudioClip _pigSound;

    // ENCAPSULATION
    [SerializeField]
    private AudioClip _cattleSound;

    // ENCAPSULATION
    [SerializeField]
    private AudioClip _goatSound;


    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        ConfigureAudioSource();
    }

    // ABSTRACTION

    private void ConfigureAudioSource()
    {
        _audioSource.loop = false;
        _audioSource.playOnAwake = false;
    }

    public void PlayGoatSound()
    {
        PlaySound(_goatSound);
    }

    public void PlayCattleSound()
    {
        PlaySound(_cattleSound);
    }

    public void PlayPigSound()
    {
        PlaySound(_pigSound);
    }

    // ABSTRACTION

    void PlaySound(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
