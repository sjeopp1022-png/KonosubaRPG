using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 씬 전환을 담당하는 매니저
/// (게임 화면 이동 전담)
/// </summary>
public class SceneLoader : MonoBehaviour
{
    // 싱글톤
    public static SceneLoader Instance;

    private void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 바뀌어도 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 씬 이름으로 이동
    /// </summary>
    public void LoadScene(string sceneName)
    {
        Debug.Log("씬 이동: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// 현재 씬 재시작
    /// </summary>
    public void ReloadScene()
    {
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.name);
    }
}