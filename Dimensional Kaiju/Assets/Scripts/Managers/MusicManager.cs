using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    AudioSource _musicSource;
    AudioClip _audioClip;

   [field: SerializeField] public AudioClip BattleMusic { get; set; }
   [field: SerializeField] public AudioClip MenuMusic { get; set; }

    protected override void Initialize()
    {
        _musicSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip clip, bool loopSetting)
    {
        _audioClip = clip;

        if (_musicSource == null)
        {
            this.gameObject.AddComponent<AudioSource>();
        }

        _musicSource.clip = clip;
        _musicSource.loop = loopSetting;
        _musicSource.PlayOneShot(_audioClip);
    }

    public void StopMusic()
    {
        if (_musicSource == null) { return; }

        _musicSource.Stop();
    }
}