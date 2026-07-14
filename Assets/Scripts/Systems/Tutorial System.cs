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


            // Next 버튼 진행자를 TutorialSystem으로 변경
            DialogueSystem.Instance.SetNextAction(NextLine);
        }


        ShowCurrentLine();
    }



    // 다음 튜토리얼 대사
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



    // 현재 튜토리얼 대사 출력
    private void ShowCurrentLine()
    {
        if (tutorialLines.Count == 0)
        {
            Debug.LogWarning("튜토리얼 데이터가 없습니다.");
            return;
        }


        TutorialData data = tutorialLines[currentIndex];


        if (DialogueSystem.Instance != null)
        {
            DialogueSystem.Instance.ShowDialogue(
                data.speaker,
                data.dialogue,
                data.characterImage
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


        if (homeManager != null)
        {
            homeManager.EndTutorial();
        }
        else
        {
            Debug.LogWarning("HomeManager 연결 필요");
        }
    }
}



[System.Serializable]
public class TutorialData
{
    public string speaker;


    [TextArea(2, 5)]
    public string dialogue;


    public Sprite characterImage;
}