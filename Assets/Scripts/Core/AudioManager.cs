using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    private AudioSource audioSource;
    private AudioClip jumpClip;
    private AudioClip passClip;

    private bool isMuted;

    private void Awake()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();

        jumpClip = Resources.Load<AudioClip>("Sounds/BallJumpingSound");
        passClip = Resources.Load<AudioClip>("Sounds/PassSound");
    }

    public void PlayJumpingSound()
    {
        if (isMuted) return;

        audioSource.PlayRandomly(jumpClip);
    }

    public void PlayPassSound()
    {
        if (isMuted) return;

        audioSource.pitch += 0.1f;
        audioSource.PlayOneShot(passClip);
    }

    public bool ToggleMute()
    {
        if (isMuted)
        {
            isMuted = false;
        }
        else
        {
            isMuted = true;
        }

        return isMuted;
    }
}
