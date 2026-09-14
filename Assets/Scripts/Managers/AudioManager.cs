using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("Audio Data")]
    public AudioData titleAudioData;

    private AudioClip currentBGM;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // 타이틀 BGM 재생
            if (titleAudioData != null)
            {
                PlayBGM(titleAudioData.bgm);
            }
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    // BGM 재생
    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (clip == null)
            return;

        if (currentBGM == clip && bgmSource.isPlaying)
            return;

        currentBGM = clip;

        bgmSource.Stop();
        bgmSource.clip = clip;
        bgmSource.loop = loop;
        bgmSource.Play();
    }

    // BGM 정지
    public void StopBGM()
    {
        bgmSource.Stop();
        bgmSource.clip = null;
        currentBGM = null;
    }

    // 효과음 재생
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null)
            return;

        sfxSource.PlayOneShot(clip);
    }

    // 전체 볼륨
    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = Mathf.Clamp01(volume);
    }

    // BGM 볼륨
    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = Mathf.Clamp01(volume);
    }

    // 효과음 볼륨
    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = Mathf.Clamp01(volume);
    }
}