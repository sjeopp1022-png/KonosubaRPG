using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    public float minimumLoadingTime = 2f;

    private bool isLoading = false;

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

    public void LoadScene(string sceneName)
    {
        if (isLoading)
            return;

        StartCoroutine(LoadRoutine(sceneName));
    }

    private IEnumerator LoadRoutine(string sceneName)
    {
        isLoading = true;

        UIManager.Instance.ShowLoading();

        // 로딩 시작과 동시에 BGM 정지
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.StopBGM();
        }

        // UI를 먼저 그리게 한다.
        yield return null;

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        float timer = 0f;

        while (!operation.isDone)
        {
            timer += Time.deltaTime;

            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            float display = Mathf.Min(progress, timer / minimumLoadingTime);

            UIManager.Instance.SetLoadingProgress(display);

            if (operation.progress >= 0.9f &&
                timer >= minimumLoadingTime)
            {
                UIManager.Instance.SetLoadingProgress(1);

                yield return new WaitForSeconds(0.2f);

                operation.allowSceneActivation = true;
            }

            yield return null;
        }

        UIManager.Instance.HideLoading();

        isLoading = false;
    }
}