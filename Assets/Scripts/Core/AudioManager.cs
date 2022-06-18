using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    public bool IsMuted { get; private set; }

    private AudioSource audioSource;
    private AudioClip jumpClip;
    private AudioClip passClip;

    private void Awake()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();

        jumpClip = Resources.Load<AudioClip>("Sounds/BallJumpingSound");
        passClip = Resources.Load<AudioClip>("Sounds/PassSound");

        LoadSettings();
    }

    private void LoadSettings()
    {
        IsMuted = PlayerPrefs.GetInt(nameof(IsMuted), 0) != 0;
    }

    public void PlayJumpingSound()
    {
        if (IsMuted) return;

        audioSource.PlayRandomly(jumpClip);
    }

    public void PlayPassSound()
    {
        if (IsMuted) return;

        audioSource.pitch += 0.1f;
        audioSource.PlayOneShot(passClip);
    }

    public bool ToggleMute()
    {
        IsMuted = !IsMuted;

        PlayerPrefs.SetInt(nameof(IsMuted), Convert.ToInt32(IsMuted));

        return IsMuted;
    }
}
