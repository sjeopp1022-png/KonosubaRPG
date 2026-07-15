using UnityEngine;
using System;
using System.Collections;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance;

    [Header("현재 사용할 DialogueBox")]
    private DialogueBox currentDialogueBox;

    [Header("타이핑 속도")]
    public float typingSpeed = 0.03f;

    private Coroutine typingCoroutine;

    private string currentText;

    private bool isTyping = false;

    private Action nextAction;

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

    // 사용할 DialogueBox 지정
    public void SetDialogueBox(DialogueBox dialogueBox)
    {
        currentDialogueBox = dialogueBox;

        currentDialogueBox.nextButton.onClick.RemoveAllListeners();
        currentDialogueBox.nextButton.onClick.AddListener(Next);
    }

    // 다음 버튼 동작 지정
    public void SetNextAction(Action action)
    {
        nextAction = action;
    }

    // 대사 출력
    public void ShowDialogue(string speaker, string dialogue)
    {
        if (currentDialogueBox == null)
            return;

        currentDialogueBox.gameObject.SetActive(true);

        currentDialogueBox.nameText.text = speaker;

        currentText = dialogue;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        isTyping = true;

        currentDialogueBox.dialogueText.text = "";

        foreach (char c in currentText)
        {
            currentDialogueBox.dialogueText.text += c;

            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    // DialogueBox에서 호출
    public void Next()
    {
        if (currentDialogueBox == null)
            return;

        // 타이핑 중이면 즉시 출력
        if (isTyping)
        {
            if (typingCoroutine != null)
                StopCoroutine(typingCoroutine);

            currentDialogueBox.dialogueText.text = currentText;

            isTyping = false;

            return;
        }

        nextAction?.Invoke();
    }

    // 대사창 숨기기
    public void HideDialogue()
    {
        if (currentDialogueBox == null)
            return;

        currentDialogueBox.gameObject.SetActive(false);
    }
}