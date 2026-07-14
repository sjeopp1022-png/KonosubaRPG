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
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }



    // 스토리 시작
    public void StartStory()
    {
        currentIndex = 0;


        if(DialogueSystem.Instance != null)
        {
            // 스토리용 대화창 지정
            DialogueSystem.Instance.SetDialogueBox(storyDialogueBox);

            // 다음 버튼이 StorySystem을 호출하도록 설정
            DialogueSystem.Instance.SetNextAction(NextLine);
        }


        ShowCurrentLine();
    }



    // 다음 대사
    public void NextLine()
    {
        currentIndex++;


        if(currentIndex >= storyLines.Count)
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


        if(DialogueSystem.Instance != null)
        {
            DialogueSystem.Instance.ShowDialogue(
                data.speaker,
                data.dialogue,
                data.characterImage
            );
        }
    }



    // 스토리 종료
    private void EndStory()
    {
        Debug.Log("첫 스토리 종료");


        if(DialogueSystem.Instance != null)
        {
            DialogueSystem.Instance.HideDialogue();
        }


        if(homeManager != null)
        {
            homeManager.EndStory();
        }
    }
}



[System.Serializable]
public class StoryData
{
    public string speaker;


    [TextArea(2,5)]
    public string dialogue;


    public Sprite characterImage;
}