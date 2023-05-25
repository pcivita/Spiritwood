using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoadDialogue : MonoBehaviour
{
        // This function is called when the script instance is being loaded
    private void Awake()
    {
        // Makes the GameObject this script is attached to persist across scene loads
        DontDestroyOnLoad(gameObject);
    }

    // This function is called when the object becomes enabled and active
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // This function is called when the behaviour becomes disabled or inactive
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "CutScene") {

            StartCoroutine(ExampleCoroutine());


           
        }
        
    }

    IEnumerator ExampleCoroutine()
    {
        // This will pause the coroutine execution for 3 seconds
        yield return new WaitForSeconds(1);

        // After waiting for 3 seconds, this line will be executed
         DialogueTrigger dialogueTrigger = GetComponent<DialogueTrigger>();
        dialogueTrigger.TriggerDialogue();
        // Put your code here that you want to execute when the scene is loaded
       // Debug.Log("Scene loaded: " + scene.name);
    }
}