using UnityEngine;

/// <summary>
/// UI 전체를 관리하는 매니저
/// (팝업, 패널, 로딩 등 공통 UI 담당)
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("기본 UI")]
    public GameObject loadingPanel;
    public GameObject popupPanel;

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
            loadingPanel.SetActive(isOn);
    }

    /// <summary>
    /// 팝업창 ON/OFF
    /// </summary>
    public void SetPopup(bool isOn)
    {
        if (popupPanel != null)
            popupPanel.SetActive(isOn);
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