using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !hasTriggered)
        {
            // Start the dialogue
            dialogueManager.StartDialogue();
            hasTriggered = true;
        }
    }
}