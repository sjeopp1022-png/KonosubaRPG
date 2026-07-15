using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 게임 시작 초기화 + 씬 이동 담당
/// </summary>
public class BootManager : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Boot 시작");

        InitSystems();

        // 아주 짧게 대기 후 씬 이동 (안정성 확보)
        Invoke(nameof(LoadTitle), 0.5f);
    }

    private void InitSystems()
    {
        if (GameManager.Instance == null)
            Debug.LogWarning("GameManager 없음");

        if (UIManager.Instance == null)
            Debug.LogWarning("UIManager 없음");

        if (AudioManager.Instance == null)
            Debug.LogWarning("AudioManager 없음");

        if (SaveManager.Instance == null)
            Debug.LogWarning("SaveManager 없음");

        if (SceneLoader.Instance == null)
            Debug.LogWarning("SceneLoader 없음");
    }

    private void LoadTitle()
    {
        Debug.Log("Title 씬 이동");

        SceneManager.LoadScene("01_Title");
    }
}