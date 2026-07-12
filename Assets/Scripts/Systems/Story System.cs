using UnityEngine;
using System.Collections.Generic;

public class StorySystem : MonoBehaviour
{
    public static StorySystem Instance;


    [Header("첫 스토리 데이터")]
    public List<StoryData> storyLines = new List<StoryData>();


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


    // 첫 스토리 시작
    public void StartStory()
    {
        currentIndex = 0;

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


    private void ShowCurrentLine()
    {
        if (DialogueSystem.Instance == null)
        {
            Debug.LogError("DialogueSystem 없음");
            return;
        }


        StoryData data = storyLines[currentIndex];


        DialogueSystem.Instance.ShowDialogue(
            data.speaker,
            data.dialogue,
            data.characterImage
        );
    }


    private void EndStory()
    {
        Debug.Log("첫 스토리 종료");


        DialogueSystem.Instance.HideDialogue();


        if (TutorialSystem.Instance != null)
        {
            TutorialSystem.Instance.StartTutorial();
        }
    }
}



[System.Serializable]
public class StoryData
{
    public string speaker;


    [TextArea(2, 5)]
    public string dialogue;


    public Sprite characterImage;
}