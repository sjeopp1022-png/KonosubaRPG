using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance;

    [Header("캐릭터 이미지")]
    public Image leftCharacter;

    public Image rightCharacter;

    [Header("강조 설정")]
    [Range(0f, 1f)]
    public float dimAlpha = 0.4f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 왼쪽 캐릭터 표시
    public void ShowLeft(Sprite sprite)
    {
        if (sprite == null)
        {
            leftCharacter.gameObject.SetActive(false);
            return;
        }

        leftCharacter.sprite = sprite;
        leftCharacter.gameObject.SetActive(true);
    }

    // 오른쪽 캐릭터 표시
    public void ShowRight(Sprite sprite)
    {
        if (sprite == null)
        {
            rightCharacter.gameObject.SetActive(false);
            return;
        }

        rightCharacter.sprite = sprite;
        rightCharacter.gameObject.SetActive(true);
    }

    // 모두 숨기기
    public void HideAll()
    {
        leftCharacter.gameObject.SetActive(false);
        rightCharacter.gameObject.SetActive(false);
    }

    // 왼쪽 강조
    public void HighlightLeft()
    {
        if (leftCharacter.gameObject.activeSelf)
            SetAlpha(leftCharacter, 1f);

        if (rightCharacter.gameObject.activeSelf)
            SetAlpha(rightCharacter, dimAlpha);
    }

    // 오른쪽 강조
    public void HighlightRight()
    {
        if (leftCharacter.gameObject.activeSelf)
            SetAlpha(leftCharacter, dimAlpha);

        if (rightCharacter.gameObject.activeSelf)
            SetAlpha(rightCharacter, 1f);
    }

    // 둘 다 강조(나레이션용)
    public void HighlightBoth()
    {
        if (leftCharacter.gameObject.activeSelf)
            SetAlpha(leftCharacter, 1f);

        if (rightCharacter.gameObject.activeSelf)
            SetAlpha(rightCharacter, 1f);
    }

    private void SetAlpha(Image image, float alpha)
    {
        Color c = image.color;
        c.a = alpha;
        image.color = c;
    }
}