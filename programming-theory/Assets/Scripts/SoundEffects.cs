using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffects : MonoBehaviour
{
    [SerializeField]
    private AudioClip _pigSound;

    [SerializeField]
    private AudioClip _cattleSound;

    [SerializeField]
    private AudioClip _goatSound;


    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
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

    void PlaySound(AudioClip clip)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
