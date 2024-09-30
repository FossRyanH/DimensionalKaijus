using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    AudioClip _audioClip;
    AudioSource _audioSource;

    protected override void Initialize()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip clip)
    {
        _audioClip = clip;

        if (_audioSource == null)
        {
            this.gameObject.AddComponent<AudioSource>();
        }

        _audioSource.PlayOneShot(clip);
    }
}
