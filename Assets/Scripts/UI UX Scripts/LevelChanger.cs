using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    public string levelToLoad;


    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButtonDown(0)) {
        //     Debug.Log("Hello");
        //     FadetoLevel(levelToLoad);
        // }
    }

    public void FadetoLevel (string LevelIndex) {
        levelToLoad = LevelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        Debug.Log(levelToLoad);
        SceneManager.LoadScene(levelToLoad);
    }
}
