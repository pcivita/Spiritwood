using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void StartGame() {
        Debug.Log("load scene 4");
        SceneManager.LoadScene(4);
    }
}
