using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] private PlayerController playerController;

    private string[] initialDialogue = new string[]
    {
        "Ugh...Where am I?",
        "I feel...dead",
        "Why the heck am I bouncing up and down?"
    };

    private string[] triggerDialogue = new string[]
    {
        "Ghosty?",
        "My name isn't Ghosty it's Cindy"
    };

    private string[] currentDialogueSet;  // Keeps track of which dialogue array we're using
    private int currentDialogueIndex = 0;
    private bool isTyping = false;
    private Coroutine typeCoroutine;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentDialogueSet = initialDialogue;
        typeCoroutine = StartCoroutine(TypeText(currentDialogueSet[currentDialogueIndex]));
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void StartDialogue()
    {
        currentDialogueIndex = 0;
        currentDialogueSet = triggerDialogue;
        spriteRenderer.enabled = true;
        typeCoroutine = StartCoroutine(TypeText(currentDialogueSet[currentDialogueIndex]));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isTyping)
            {
                SkipTyping();
            }
            else
            {
                currentDialogueIndex++;
                if (currentDialogueIndex < currentDialogueSet.Length)  // Use currentDialogueSet
                {
                    typeCoroutine = StartCoroutine(TypeText(currentDialogueSet[currentDialogueIndex]));
                }
            }
        }

        if (currentDialogueIndex >= currentDialogueSet.Length)  // Use currentDialogueSet
        {
            spriteRenderer.enabled = false;
            dialogueText.text = "";
        }

        if (spriteRenderer.enabled)
        {
            playerController.rb.velocity = new Vector2(0, 0);
            playerController.enabled = false;
        }
        else
        {
            playerController.enabled = true;

        }
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";


        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;

    }


    public void SkipTyping()
    {
        if (isTyping)
        {
            StopCoroutine(typeCoroutine);
            dialogueText.text = currentDialogueSet[currentDialogueIndex];  // Use currentDialogueSet
            isTyping = false;

        }
    }
}