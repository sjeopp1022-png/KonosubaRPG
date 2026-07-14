using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance;


    [Header("현재 DialogueBox")]
    public DialogueBox currentDialogueBox;


    // 현재 대사를 진행하는 시스템
    private System.Action nextAction;



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



    // 사용할 DialogueBox 변경
    public void SetDialogueBox(DialogueBox box)
    {
        currentDialogueBox = box;
    }



    // 다음 버튼 동작 설정
    public void SetNextAction(System.Action action)
    {
        nextAction = action;
    }



    // 대사 출력
    public void ShowDialogue(
        string speaker,
        string text,
        Sprite image = null)
    {
        if(currentDialogueBox == null)
        {
            Debug.LogError("DialogueBox가 없습니다.");
            return;
        }


        currentDialogueBox.Show(
            speaker,
            text,
            image
        );
    }



    // Next 버튼 호출
    public void Next()
    {
        Debug.Log("다음 대사");


        if(nextAction != null)
        {
            nextAction.Invoke();
        }
        else
        {
            Debug.LogWarning("다음 진행 대상이 없습니다.");
        }
    }



    public void HideDialogue()
    {
        if(currentDialogueBox != null)
        {
            currentDialogueBox.Hide();
        }
    }
}