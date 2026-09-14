using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [Header("이동할 씬")]
    public string nextSceneName = "02_Home";

    [Header("버튼")]
    public Button touchToStartButton;
    public Button resetButton;

    [Header("초기화 확인 패널")]
    public GameObject resetConfirmPanel;
    public Button yesButton;
    public Button noButton;

    [Header("BGM")]
    public AudioClip titleBGM;   // 타이틀 씬에서 재생할 BGM 클립

    private void Start()
    {
        touchToStartButton.onClick.AddListener(StartGame);

        resetButton.onClick.AddListener(OpenResetPanel);

        yesButton.onClick.AddListener(ResetData);

        noButton.onClick.AddListener(CloseResetPanel);

        resetConfirmPanel.SetActive(false);

        PlayTitleBGM();
    }

    private void PlayTitleBGM()
    {
        if (AudioManager.Instance != null && titleBGM != null)
        {
            AudioManager.Instance.PlayBGM(titleBGM);
        }
    }

    private void StartGame()
    {
        Debug.Log("02_Home 이동");

        if (AudioManager.Instance != null)
        {
        AudioManager.Instance.StopBGM();
        }

        SceneLoader.Instance.LoadScene(nextSceneName);
    }

    private void OpenResetPanel()
    {
        resetConfirmPanel.SetActive(true);
    }

    private void CloseResetPanel()
    {
        resetConfirmPanel.SetActive(false);
    }

    private void ResetData()
    {
        Debug.Log("데이터 초기화");

        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        resetConfirmPanel.SetActive(false);
    }
}