using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject instructionsUI;
    [SerializeField] TextMeshProUGUI instructionsText;
    [SerializeField] List<string> instructionsList;
    int currentIndex;

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ToggleInstructions(bool isActive)
    {
        instructionsUI.SetActive(isActive);

        if (instructionsUI.activeInHierarchy)
        {
            currentIndex = 0;
            instructionsText.text = instructionsList[currentIndex];
        }
    }

    public void CycleInstructions()
    {
        ++currentIndex;

        if (currentIndex == instructionsList.Count)
        {
            instructionsUI.SetActive(false);
            currentIndex = 0;
        }

        instructionsText.text = instructionsList[currentIndex];
    }
}
