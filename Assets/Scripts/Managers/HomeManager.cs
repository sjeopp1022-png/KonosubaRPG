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


    // 홈 진입 시 첫 스토리 시작
    private void StartHomeStory()
    {
        menuPanel.SetActive(false);

        storyPanel.SetActive(true);

        tutorialPanel.SetActive(false);

        Debug.Log("홈 첫 스토리 시작");
    }


    // 스토리 종료 후 메뉴 표시
    public void EndStory()
    {
        storyPanel.SetActive(false);

        tutorialPanel.SetActive(true);

        Debug.Log("튜토리얼 시작");
    }


    // 튜토리얼 종료
    public void EndTutorial()
    {
        tutorialPanel.SetActive(false);

        menuPanel.SetActive(true);

        Debug.Log("홈 메뉴 활성화");
    }
}