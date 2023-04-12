using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject instructionsUI;

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ToggleInstructions(bool isActive)
    {
        instructionsUI.SetActive(isActive);
    }
}
