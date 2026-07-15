using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;


    [Header("Loading Canvas")]
    public GameObject loadingCanvas;
    public Slider loadingSlider;
    public TMP_Text loadingText;


    [Header("Popup")]
    public GameObject popupPanel;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);

            ResetUI();
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void ShowLoading()
    {
        if (loadingCanvas == null)
        {
            Debug.LogWarning("LoadingCanvas 없음");
            return;
        }


        loadingCanvas.SetActive(true);


        if (loadingSlider != null)
            loadingSlider.value = 0;


        if (loadingText != null)
            loadingText.text = "Loading... 0%";


        Canvas.ForceUpdateCanvases();
    }



    public void SetLoadingProgress(float progress)
    {
        if (loadingSlider != null)
            loadingSlider.value = progress;


        if (loadingText != null)
            loadingText.text =
                $"Loading... {(int)(progress * 100)}%";
    }



    public void HideLoading()
    {
        if (loadingCanvas != null)
            loadingCanvas.SetActive(false);
    }



    public void SetPopup(bool on)
    {
        if (popupPanel != null)
            popupPanel.SetActive(on);
    }



    public void ResetUI()
    {
        HideLoading();
        SetPopup(false);
    }
}