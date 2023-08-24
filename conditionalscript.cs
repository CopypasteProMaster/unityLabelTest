
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class conditionalscript : MonoBehaviour
{
    public Button conditional; // Drag and drop your UI Button component here in the Inspector
    public GameObject currentPanel; // Drag and drop the current panel here in the Inspector
    public GameObject nextPanel; // Drag and drop the next panel here in the Inspector

    private void Start()
    {
        conditional.onClick.AddListener(nextPanel_);
    }

    private void nextPanel_()
    {
        currentPanel.SetActive(false); // Hide the current panel
        nextPanel.SetActive(true); // Show the next panel
    }
}