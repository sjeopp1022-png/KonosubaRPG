using UnityEngine;

public class HomeManager : MonoBehaviour
{
    [Header("패널")]
    public GameObject menuPanel;
    public GameObject storyPanel;
    public GameObject tutorialPanel;



    private void Start()
    {
        StartHomeStory();
    }



    // 첫 진입 스토리
    private void StartHomeStory()
    {
        menuPanel.SetActive(false);

        storyPanel.SetActive(true);

        tutorialPanel.SetActive(false);


        Debug.Log("홈 첫 스토리 시작");


        if(StorySystem.Instance != null)
        {
            StorySystem.Instance.StartStory();
        }
    }



    // 스토리 종료 후
    public void EndStory()
    {
        storyPanel.SetActive(false);


        // 메뉴와 튜토리얼 동시 표시
        menuPanel.SetActive(true);

        tutorialPanel.SetActive(true);


        Debug.Log("홈 메뉴 + 튜토리얼 시작");


        if(TutorialSystem.Instance != null)
        {
            TutorialSystem.Instance.StartTutorial();
        }
    }



    // 튜토리얼 종료
    public void EndTutorial()
    {
        tutorialPanel.SetActive(false);


        Debug.Log("튜토리얼 종료");
    }
}