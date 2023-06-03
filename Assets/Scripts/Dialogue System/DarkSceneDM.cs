using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro namespace
using UnityEngine.SceneManagement;


public class DarkSceneDM : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image dialogueBox;
    private Dialogue dialogue;
    public FloatRef Speed;

    public bool inSentence = false;

    private Queue<string> sentences;

    private Queue<string> names;

    public TopDownMovement playerMovement;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (inSentence)
            {
                Speed.value = 0.01f;
            }
            else
            {
                DisplayNextSentence();
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("inside Start");
        Speed.value = 0.05f;
        sentences = new Queue<string>();
        names = new Queue<string>();
        sentences.Clear();
        names.Clear();

        Debug.Log(SceneManager.GetActiveScene().buildIndex);

        StartDialogue();
    }

    public void StartDialogue()
    {
        Debug.Log("start dialogue");
        dialogueBox.gameObject.SetActive(true);

        names.Enqueue("Master Oogway");
        names.Enqueue("Parrot");
        names.Enqueue("Master Oogway");

        sentences.Enqueue("Ah… she’s coming to her senses.");
        sentences.Enqueue("What will we tell her?");
        sentences.Enqueue("Sshhh…");

        DisplayNextSentence();
    }


    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        nameText.text = names.Dequeue();
        // This is if user tries to skip sentence
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, Speed));

    }

    IEnumerator TypeSentence(string sentence, FloatRef speed)
    {
        inSentence = true;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            //  Debug.Log(speed);
            // wait a frame;
            yield return new WaitForSeconds(speed.value);
        }
        speed.value = 0.05f;
        inSentence = false;

    }

    void EndDialogue()
    {
        dialogueBox.gameObject.SetActive(false);
        Debug.Log("End of Convo");
        SceneManager.LoadScene(1);
    }


}
