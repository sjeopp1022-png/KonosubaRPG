using UnityEngine;

/// <summary>
/// 게임 BGM(배경음악)을 관리하는 매니저
/// 씬마다 음악 변경, 재생, 정지 담당
/// </summary>
public class BGMManager : MonoBehaviour
{
    // 싱글톤
    public static BGMManager Instance;

    [Header("AudioSource (필수)")]
    public AudioSource audioSource;

    private void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // AudioSource 자동 가져오기
            if (audioSource == null)
                audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// BGM 재생
    /// </summary>
    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (clip == null)
        {
            Debug.LogWarning("BGM 클립이 없음");
            return;
        }

        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.Play();
    }

    /// <summary>
    /// BGM 정지
    /// </summary>
    public void StopBGM()
    {
        audioSource.Stop();
    }

    /// <summary>
    /// 볼륨 설정
    /// </summary>
    public void SetVolume(float volume)
    {
        audioSource.volume = Mathf.Clamp01(volume);
    }
}