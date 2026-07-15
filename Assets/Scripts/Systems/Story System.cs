using UnityEngine;
using System.Collections.Generic;

public class StorySystem : MonoBehaviour
{
    public static StorySystem Instance;

    [Header("스토리 데이터")]
    public List<StoryData> storyLines = new List<StoryData>();

    [Header("연결")]
    public DialogueBox storyDialogueBox;
    public HomeManager homeManager;

    private int currentIndex = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // 스토리 시작
    public void StartStory()
    {
        currentIndex = 0;

        if (DialogueSystem.Instance != null)
        {
            DialogueSystem.Instance.SetDialogueBox(storyDialogueBox);
            DialogueSystem.Instance.SetNextAction(NextLine);
        }

        ShowCurrentLine();
    }

    // 다음 대사
    public void NextLine()
    {
        currentIndex++;

        if (currentIndex >= storyLines.Count)
        {
            EndStory();
            return;
        }

        ShowCurrentLine();
    }

    // 현재 대사 출력
    private void ShowCurrentLine()
    {
        StoryData data = storyLines[currentIndex];

        // 배경
        if (BackgroundManager.Instance != null)
        {
            BackgroundManager.Instance.ChangeBackground(data.background);
        }

        // 캐릭터
        if (CharacterManager.Instance != null)
        {
            CharacterManager.Instance.ShowLeft(data.leftCharacter);
            CharacterManager.Instance.ShowRight(data.rightCharacter);

            switch (data.speakerPosition)
            {
                case SpeakerPosition.Left:
                    CharacterManager.Instance.HighlightLeft();
                    break;

                case SpeakerPosition.Right:
                    CharacterManager.Instance.HighlightRight();
                    break;

                default:
                    CharacterManager.Instance.HighlightBoth();
                    break;
            }
        }

        // BGM
        if (AudioManager.Instance != null && data.bgm != null)
        {
            AudioManager.Instance.PlayBGM(data.bgm);
        }

        // 효과음
        if (AudioManager.Instance != null && data.sfx != null)
        {
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

    // 스토리 종료
    private void EndStory()
    {
        Debug.Log("첫 스토리 종료");

        if (DialogueSystem.Instance != null)
            DialogueSystem.Instance.HideDialogue();

        if (CharacterManager.Instance != null)
            CharacterManager.Instance.HideAll();

        if (homeManager != null)
            homeManager.EndStory();
    }
}

[System.Serializable]
public class StoryData
{
    [Header("화자")]
    public string speaker;

    [TextArea(2, 5)]
    public string dialogue;

    [Header("캐릭터")]
    public Sprite leftCharacter;
    public Sprite rightCharacter;

    [Header("화자 위치")]
    public SpeakerPosition speakerPosition;

    [Header("배경")]
    public Sprite background;

    [Header("사운드")]
    public AudioClip bgm;
    public AudioClip sfx;
}

public enum SpeakerPosition
{
    None,
    Left,
    Right
}