using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// 타이틀 화면 제어
/// 시작 버튼, BGM, 씬 이동 담당
/// </summary>
public class TitleManager : MonoBehaviour
{
    [Header("다음 씬 이름")]
    public string nextSceneName = "02_Home";

    [Header("시작 버튼")]
    public Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(OnClickStart);

        Debug.Log("Title 시작");
    }

    private void OnClickStart()
    {
        Debug.Log("게임 시작 버튼 클릭");

        SceneManager.LoadScene(nextSceneName);
    }
}