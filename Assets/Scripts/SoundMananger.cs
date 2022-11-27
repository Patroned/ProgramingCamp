using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundMananger : MonoBehaviour
{
    public static SoundMananger instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpAudio, hurtAudio, cherryAudio;

    private void Awake()
    {
        instance = this;
    }
    public void JumpAudio()
    {
        audioSource.clip = jumpAudio;
        audioSource.Play();
    }

    public void HurtAudio()
    {
        audioSource.clip = hurtAudio;
        audioSource.Play();
    }

    public void CherryAudio()
    {
        audioSource.clip = cherryAudio;
        audioSource.Play();
    }
}