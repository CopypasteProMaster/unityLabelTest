
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class textnonext : MonoBehaviour
{
    public Text uiText; // Drag and drop your UI Text component here in the Inspector
   
    public float cpsText = 2.0f; // Clicks Per Second for text animation
   

    private void Start()
    {
        uiText.text = ""; // Clear the text initially
      
        StartCoroutine(AnimateProgressively());
    }

    private IEnumerator AnimateProgressively()
    {
        string fullText = "shhh.....";
        int lettersToShow = 0;
        float delayText = 1.0f / cpsText;

        while (lettersToShow <= fullText.Length)
        {
            uiText.text = fullText.Substring(0, lettersToShow);
            lettersToShow++;
            yield return new WaitForSeconds(delayText);
        }

        // Show the "Yes" and "No" buttons after text animation is complete
     
    }
}