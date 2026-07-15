using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    [Header("패널")]
    public GameObject menuPanel;
    public GameObject storyPanel;
    public GameObject tutorialPanel;

    [Header("로딩")]
    public GameObject loadingPanel;

    [Header("이동할 씬")]
    public string guildSceneName = "02_Guild";

    private void Start()
    {
        StartHomeStory();
    }

    // 홈 첫 스토리
    private void StartHomeStory()
    {
        menuPanel.SetActive(false);
        storyPanel.SetActive(true);
        tutorialPanel.SetActive(false);

        if (StorySystem.Instance != null)
        {
            StorySystem.Instance.StartStory();
        }
    }

    // 스토리 종료
    public void EndStory()
    {
        storyPanel.SetActive(false);

        tutorialPanel.SetActive(true);

        if (TutorialSystem.Instance != null)
        {
            TutorialSystem.Instance.StartTutorial();
        }
    }

    // 튜토리얼 종료
    public void EndTutorial()
    {
        tutorialPanel.SetActive(false);

        menuPanel.SetActive(true);
    }

    // 길드 버튼
    public void OnClickGuild()
    {
        SceneLoader.Instance.LoadScene("03_Guild");
    }
}