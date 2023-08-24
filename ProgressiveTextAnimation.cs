
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgressiveTextAnimation : MonoBehaviour
{
    public Text uiText; // Drag and drop your UI Text component here in the Inspector
    public float cps = 2.0f; // Clicks Per Second

    private void Start()
    {
        StartCoroutine(AnimateProgressively());
    }

    private IEnumerator AnimateProgressively()
    {
        string fullText = uiText.text;
        int lettersToShow = 1;
        float delay = 1.0f / cps;

        while (lettersToShow <= fullText.Length)
        {
            uiText.text = fullText.Substring(0, lettersToShow);
            yield return new WaitForSeconds(delay);

            lettersToShow++;
        }
    }
}

