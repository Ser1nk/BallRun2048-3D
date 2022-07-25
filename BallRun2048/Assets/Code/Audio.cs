using UnityEngine;

public class Audio : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource _mergeSound;
    [SerializeField] private AudioSource _damageSound;
    [SerializeField] private AudioSource _hitSound;
    [SerializeField] private AudioSource _winSound;

    public void PlayMergeSound()
    {
        _mergeSound.Play();
    }

    public void PlayDamageSound()
    {
        _damageSound.Play();
    }

    public void PlayHitSound()
    {
        _hitSound.Play();
    }
    public void PlayWinSound()
    {
        _winSound.Play();
    }
}
