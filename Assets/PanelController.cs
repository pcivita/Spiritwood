using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public Button yourButton; // Assign in inspector
    public GameObject yourPanel; // Assign in inspector

    void Start()
    {
        yourButton.onClick.AddListener(TogglePanel);
        yourPanel.SetActive(false); // Set panel to be hidden by default
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanel();
        }
    }

    void TogglePanel()
    {
        yourPanel.SetActive(!yourPanel.activeSelf);
    }
}