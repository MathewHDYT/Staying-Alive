using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }
}
