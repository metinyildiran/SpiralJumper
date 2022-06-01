using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_AudioManager", menuName = "ScriptableObjects/SO_AudioManager")]
public class SO_AudioManager : ScriptableObject
{
    [SerializeField] private AudioClip jumpSound;

    public event Action<AudioClip> OnJump;

    public void PlayJumpingSound()
    {
        OnJump?.Invoke(jumpSound);
    }
}
