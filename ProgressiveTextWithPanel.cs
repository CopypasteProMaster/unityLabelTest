using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressiveTextWithPanel : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;
    public Transform playerCameraRoot;
    public float xThreshold = 265.4044f;

    public Text uiText;
    public float cpsText = 10.0f;

    private bool textAnimationComplete = false;

    private void Start()
    {
        string initialText = uiText.text;
        uiText.text = "";
        StartCoroutine(AnimateProgressively(initialText));
    }

    private IEnumerator AnimateProgressively(string initialText)
    {
        string fullText = initialText;
        int lettersToShow = 0;
        float delayText = 1.0f / cpsText;

        while (lettersToShow <= fullText.Length)
        {
            uiText.text = fullText.Substring(0, lettersToShow);
            lettersToShow++;
            yield return new WaitForSeconds(delayText);
        }

        textAnimationComplete = true;
    }

    private void Update()
    {
        // Check if the camera root's X position is greater than the threshold
        float cameraX = playerCameraRoot.position.x;
        float angle = Vector3.Angle(playerCameraRoot.forward, playerCameraRoot.up);

        if (cameraX > xThreshold && angle <= 90 && textAnimationComplete)
        {
            ChangePanel();
        }
    }

    private void ChangePanel()
    {
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
}



/*
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressiveTextWithPanel : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;
    public Transform playerCameraRoot;
    public float xThreshold = -5.0f; // Change this threshold value

    public Text uiText;
    public float cpsText = 2.0f;

    private bool textAnimationComplete = false; // Added boolean flag

    private void Start()
    {
        string initialText = uiText.text;
        uiText.text = "";
        StartCoroutine(AnimateProgressively(initialText));
    }

    private IEnumerator AnimateProgressively(string initialText)
    {
        string fullText = initialText;
        int lettersToShow = 0;
        float delayText = 1.0f / cpsText;

        while (lettersToShow <= fullText.Length)
        {
            uiText.text = fullText.Substring(0, lettersToShow);
            lettersToShow++;
            yield return new WaitForSeconds(delayText);
        }

        textAnimationComplete = true; // Set the flag to indicate text animation is complete
    }

    private void Update()
    {
        // Check if the camera root's X position is greater than the threshold
        if (textAnimationComplete && playerCameraRoot.position.x > xThreshold)
        {
            ChangePanel();
        }
    }

    private void ChangePanel()
    {
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
}
*/