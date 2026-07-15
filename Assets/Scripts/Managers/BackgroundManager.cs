using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager Instance;

    [Header("배경")]
    public Image backgroundImage;

    [Header("페이드")]
    public Image fadeImage;

    public float fadeTime = 0.4f;

    private Sprite currentBackground;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ChangeBackground(Sprite background)
    {
        if (background == null)
            return;

        if (currentBackground == background)
            return;

        StopAllCoroutines();
        StartCoroutine(FadeBackground(background));
    }

    private IEnumerator FadeBackground(Sprite nextBackground)
    {
        // Fade Out
        float t = 0f;

        while (t < fadeTime)
        {
            t += Time.deltaTime;

            Color c = fadeImage.color;
            c.a = Mathf.Lerp(0f, 1f, t / fadeTime);
            fadeImage.color = c;

            yield return null;
        }

        backgroundImage.sprite = nextBackground;
        currentBackground = nextBackground;

        // Fade In
        t = 0f;

        while (t < fadeTime)
        {
            t += Time.deltaTime;

            Color c = fadeImage.color;
            c.a = Mathf.Lerp(1f, 0f, t / fadeTime);
            fadeImage.color = c;

            yield return null;
        }

        Color end = fadeImage.color;
        end.a = 0f;
        fadeImage.color = end;
    }
}