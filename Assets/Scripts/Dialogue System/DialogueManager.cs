using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro namespace


public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    //public Text dialogueText;
    public TextMeshProUGUI dialogueText;
    public Image dialogueBox;
    private Dialogue dialogue;
    public FloatRef Speed;
    
    public bool inSentence = false;
    
    private Queue<string> names;
    private Queue<string> sentences;

    public TopDownMovement playerMovement;
   
    void Update() {
        if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space)) {
            if (inSentence) {
                Speed.value = 0.01f; 
            } else {
                DisplayNextSentence();
            }
           
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Speed.value = 0.05f;
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue (DialogueList dialogueList, int count) {
        playerMovement.movementEnabled = false;
        playerMovement.inConversation = true;

        dialogueBox.gameObject.SetActive(true);

        // First loading
        if (count == 1) {
            sentences.Clear();
            names.Clear();
            foreach (string sentence in dialogueList.dialogues[0].sentences) {
                string[] subs = sentence.Split(':');
                Debug.Log($"sentence: {sentence}");
                Debug.Log($"subs length: {subs.Length}");
                // silence
                if (subs.Length == 1) {
                    names.Enqueue("");
                    sentences.Enqueue(sentence);
                    Debug.Log($"Adding: {sentence}");
                }
                // someone talking
                else {
                    names.Enqueue(subs[0]);
                    sentences.Enqueue(subs[1]);
                    Debug.Log($"Adding: {subs[1]}");
                }
            }
            Debug.Log($"sentences count: {sentences.Count}");
            Debug.Log($"names count: {names.Count}");
            DisplayNextSentence();
        }
        else {
            if (dialogueList.dialogues.Count == 1) {
                dialogue = dialogueList.dialogues[0];
            } else {
                int index = Random.Range(0, dialogueList.dialogues.Count);
                dialogue = dialogueList.dialogues[count % dialogueList.dialogues.Count];
            }
            nameText.text = dialogue.name;
            sentences.Clear();

            foreach (string sentence in dialogue.sentences) {
                sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }

    }

    public void DisplayNextSentence () {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        nameText.text = names.Dequeue();
        // This is if user tries to skip sentence
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, Speed));
    }

    IEnumerator TypeSentence (string sentence, FloatRef speed) {
        inSentence = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
          //  Debug.Log(speed);
            // wait a frame;
            yield return new WaitForSeconds(speed.value);
        }
        speed.value = 0.05f;
        inSentence = false;

    }
    
    void EndDialogue () {
        playerMovement.movementEnabled = true;
        playerMovement.inConversation = false;
        dialogueBox.gameObject.SetActive(false);
        Debug.Log("End of Convo");
    }

    
}
