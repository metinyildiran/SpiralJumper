using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    private AudioSource audioSource;
    private AudioClip jumpClip;
    private AudioClip passClip;

    private void Awake()
    {
        Instance = this;

        audioSource = GetComponent<AudioSource>();

        jumpClip = Resources.Load<AudioClip>("Sounds/BallJumpingSound");
        passClip = Resources.Load<AudioClip>("Sounds/PassSound");
    }

    public void PlayJumpingSound()
    {
        audioSource.PlayRandomly(jumpClip);
    }

    public void PlayPassSound()
    {
        audioSource.pitch += 0.1f;
        audioSource.PlayOneShot(passClip);
    }
}
