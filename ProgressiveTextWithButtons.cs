using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressiveTextWithButtons : MonoBehaviour
{
    public Text uiText;
    public Button yesButton;
    public Button noButton;
    public float cpsText = 2.0f;
    public float cpsButtons = 1.0f;

    private void Start()
    {
        // Store the initial text from the UI Text component
        string initialText = uiText.text;

        uiText.text = "";
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);

        StartCoroutine(AnimateProgressively(initialText)); // Pass the initialText to the coroutine
    }

    private IEnumerator AnimateProgressively(string initialText) // Accept initialText as a parameter
    {
        string fullText = initialText; // Use the initialText instead of the fixed string
        int lettersToShow = 0;
        float delayText = 1.0f / cpsText;

        while (lettersToShow <= fullText.Length)
        {
            uiText.text = fullText.Substring(0, lettersToShow);
            lettersToShow++;
            yield return new WaitForSeconds(delayText);
        }

        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
    }
}



