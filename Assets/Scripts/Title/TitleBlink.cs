using UnityEngine;
using TMPro;

/// <summary>
/// Title 화면의 Touch To Start 깜빡임 효과
/// </summary>
public class TitleBlink : MonoBehaviour
{
    [Header("깜빡임 속도")]
    public float blinkSpeed = 2f;

    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        float alpha =
            (Mathf.Sin(Time.time * blinkSpeed) + 1f) / 2f;

        Color color = text.color;

        color.a = alpha;

        text.color = color;
    }
}