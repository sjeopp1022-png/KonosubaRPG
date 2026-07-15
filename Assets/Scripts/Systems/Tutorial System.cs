using UnityEngine;
using System.Collections.Generic;

public class TutorialSystem : MonoBehaviour
{
    public static TutorialSystem Instance;

    [Header("튜토리얼 데이터")]
    public List<TutorialData> tutorialLines = new List<TutorialData>();

    [Header("연결")]
    public DialogueBox tutorialDialogueBox;

    public HomeManager homeManager;

    private int currentIndex = 0;

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

    // 튜토리얼 시작
    public void StartTutorial()
    {
        currentIndex = 0;

        if (DialogueSystem.Instance != null)
        {
            // 튜토리얼용 DialogueBox 지정
            DialogueSystem.Instance.SetDialogueBox(tutorialDialogueBox);

            // Next 버튼 연결
            DialogueSystem.Instance.SetNextAction(NextLine);
        }

        ShowCurrentLine();
    }

    // 다음 대사
    public void NextLine()
    {
        currentIndex++;

        if (currentIndex >= tutorialLines.Count)
        {
            EndTutorial();
            return;
        }

        ShowCurrentLine();
    }

    // 현재 대사 출력
    private void ShowCurrentLine()
    {
        TutorialData data = tutorialLines[currentIndex];

        // 좌우 캐릭터
        if (CharacterManager.Instance != null)
        {
            CharacterManager.Instance.ShowLeft(data.leftCharacter);
            CharacterManager.Instance.ShowRight(data.rightCharacter);
        }

        // 배경
        if (BackgroundManager.Instance != null)
        {
            BackgroundManager.Instance.ChangeBackground(data.background);
        }

        // BGM
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayBGM(data.bgm);

            if (data.sfx != null)
                AudioManager.Instance.PlaySFX(data.sfx);
        }

        // 대사
        if (DialogueSystem.Instance != null)
        {
            DialogueSystem.Instance.ShowDialogue(
                data.speaker,
                data.dialogue
            );
        }
    }

    // 튜토리얼 종료
    private void EndTutorial()
    {
        Debug.Log("튜토리얼 종료");

        if (DialogueSystem.Instance != null)
        {
            DialogueSystem.Instance.HideDialogue();
        }

        if (CharacterManager.Instance != null)
        {
            CharacterManager.Instance.HideAll();
        }

        if (homeManager != null)
        {
            homeManager.EndTutorial();
        }
    }
}

[System.Serializable]
public class TutorialData
{
    [Header("화자")]
    public string speaker;

    [TextArea(2,5)]
    public string dialogue;

    [Header("캐릭터")]
    public Sprite leftCharacter;

    public Sprite rightCharacter;

    [Header("배경")]
    public Sprite background;

    [Header("사운드")]
    public AudioClip bgm;

    public AudioClip sfx;
}