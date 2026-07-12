using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// 씬 전환을 담당하는 매니저
/// (게임 화면 이동 전담)
/// </summary>
public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;


    [Header("로딩 설정")]
    [SerializeField]
    private float minimumLoadingTime = 2f;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    /// <summary>
    /// 씬 이동 시작
    /// </summary>
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }


    /// <summary>
    /// 비동기 씬 로딩
    /// </summary>
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        float loadingTimer = 0f;


        // 로딩 화면 표시
        if (UIManager.Instance != null)
        {
            UIManager.Instance.SetLoading(true);
        }


        AsyncOperation operation =
            SceneManager.LoadSceneAsync(sceneName);


        while (!operation.isDone || loadingTimer < minimumLoadingTime)
        {
            loadingTimer += Time.deltaTime;


            float sceneProgress =
                Mathf.Clamp01(operation.progress / 0.9f);


            float timeProgress =
                Mathf.Clamp01(loadingTimer / minimumLoadingTime);


            float progress =
                Mathf.Min(sceneProgress, timeProgress);


            if (UIManager.Instance != null)
            {
                UIManager.Instance.SetLoadingProgress(progress);
            }


            yield return null;
        }


        // 100% 표시
        if (UIManager.Instance != null)
        {
            UIManager.Instance.SetLoadingProgress(1f);

            yield return new WaitForSeconds(0.2f);

            UIManager.Instance.SetLoading(false);
        }
    }


    /// <summary>
    /// 현재 씬 재시작
    /// </summary>
    public void ReloadScene()
    {
        Scene current =
            SceneManager.GetActiveScene();

        LoadScene(current.name);
    }
}