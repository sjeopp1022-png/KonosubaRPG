using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogueBox : MonoBehaviour
{
    public Image characterImage;

    public TMP_Text nameText;

    public TMP_Text dialogueText;

    public Button nextButton;


    public float typingSpeed = 0.05f;


    private Coroutine typingCoroutine;



    private void Start()
    {
        nextButton.onClick.AddListener(OnNext);
    }



    public void Show(string speaker, string text, Sprite image = null)
    {
        gameObject.SetActive(true);


        nameText.text = speaker;


        if(image != null)
        {
            characterImage.sprite = image;
        }


        if(typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }


        typingCoroutine = StartCoroutine(TypeText(text));
    }



    private IEnumerator TypeText(string text)
    {
        dialogueText.text = "";


        foreach(char c in text)
        {
            dialogueText.text += c;

            yield return new WaitForSeconds(typingSpeed);
        }
    }



    private void OnNext()
    {
        if(DialogueSystem.Instance != null)
        {
            DialogueSystem.Instance.Next();
        }
    }



    public void Hide()
    {
        gameObject.SetActive(false);
    }
}