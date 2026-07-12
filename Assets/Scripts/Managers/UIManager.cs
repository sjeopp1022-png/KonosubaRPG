using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// UI 전체를 관리하는 매니저
/// (팝업, 로딩 등 공통 UI 담당)
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;


    [Header("기본 UI")]
    public GameObject loadingPanel;
    public GameObject popupPanel;


    [Header("로딩 UI")]
    public Slider loadingSlider;
    public TextMeshProUGUI loadingText;


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
    /// 로딩창 ON/OFF
    /// </summary>
    public void SetLoading(bool isOn)
    {
        if (loadingPanel != null)
        {
            loadingPanel.SetActive(isOn);
        }


        if (isOn)
        {
            ResetLoading();
        }
    }


    /// <summary>
    /// 로딩 진행도 표시
    /// </summary>
    public void SetLoadingProgress(float progress)
    {
        if (loadingSlider != null)
        {
            loadingSlider.value = progress;
        }


        if (loadingText != null)
        {
            int percent = Mathf.RoundToInt(progress * 100);

            loadingText.text =
                "Loading... " + percent + "%";
        }
    }


    /// <summary>
    /// 로딩 UI 초기화
    /// </summary>
    private void ResetLoading()
    {
        if (loadingSlider != null)
        {
            loadingSlider.value = 0;
        }


        if (loadingText != null)
        {
            loadingText.text = "Loading... 0%";
        }
    }


    /// <summary>
    /// 팝업창 ON/OFF
    /// </summary>
    public void SetPopup(bool isOn)
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(isOn);
        }
    }


    /// <summary>
    /// 모든 UI 초기화
    /// </summary>
    public void ResetUI()
    {
        SetLoading(false);
        SetPopup(false);
    }
}