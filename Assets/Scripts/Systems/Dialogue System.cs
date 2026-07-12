using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueSystem : MonoBehaviour
{
    public static DialogueSystem Instance;


    [Header("UI")]
    public GameObject dialoguePanel;

    public Image characterImage;

    public TMP_Text nameText;

    public TMP_Text dialogueText;

    public Button nextButton;


    [Header("설정")]
    public float typingSpeed = 0.05f;


    private string currentText;

    private Coroutine typingCoroutine;


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


    private void Start()
    {
        nextButton.onClick.AddListener(Next);
    }


    public void ShowDialogue(string speaker, string text, Sprite image = null)
    {
        dialoguePanel.SetActive(true);


        nameText.text = speaker;


        if (image != null)
        {
            characterImage.sprite = image;
        }


        currentText = text;


        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }


        typingCoroutine = StartCoroutine(TypeText());
    }



    private IEnumerator TypeText()
    {
        dialogueText.text = "";


        foreach (char letter in currentText)
        {
            dialogueText.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }
    }



    private void Next()
    {
        Debug.Log("다음 대사");
        
        // 다음 단계에서 Story System 연결
    }



    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}