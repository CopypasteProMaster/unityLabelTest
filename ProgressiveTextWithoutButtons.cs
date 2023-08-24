using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressiveTextWithoutButtons : MonoBehaviour
{
    public Text uiText;
    public float cpsText = 2.0f;

    private void Start()
    {
        // Store the initial text from the UI Text component
        string initialText = uiText.text;

        uiText.text = "";

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
    }
}
