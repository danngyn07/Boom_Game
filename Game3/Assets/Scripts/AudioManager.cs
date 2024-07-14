using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("======== Audio Clip ==========")]

    public AudioClip background;
    public AudioClip shoot;
    public AudioClip enemyDie;
    public AudioClip playerTakeDam;
    public AudioClip enemyAttack;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

    }
    public void PlaySFX(AudioClip clip , float _volume)
    {
        SFXSource.PlayOneShot(clip);
        SFXSource.volume = _volume;
    }
    
}
