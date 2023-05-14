using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;

    private Queue<string> sentences;

    public TopDownMovement playerMovement;

    void Update() {
        if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space)) {
            DisplayNextSentence();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue) {
        playerMovement.movementEnabled = false;
        playerMovement.inConversation = true;
        dialogueBox.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence () {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
    string sentence = sentences.Dequeue();
    // THis is if user tries to skip sentence
    StopAllCoroutines();
    StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            // wait a frame;
            yield return new WaitForSeconds(0.05f);
        }

    }
    
    void EndDialogue () {
        playerMovement.movementEnabled = true;
        playerMovement.inConversation = false;
        dialogueBox.SetActive(false);
        Debug.Log("End of Convo");
    }

    
}
