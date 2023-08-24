using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextAppearAnimation : MonoBehaviour
{
    public Text uiText;
    public float delayBetweenLetters = 0.1f;

    private void Start()
    {
        uiText.text = "hello player.."; // Clear the text initially
        StartCoroutine(AnimateTextAppear());
    }

    private IEnumerator AnimateTextAppear()
    {
        string originalText = uiText.text;
        
        for (int i = 0; i < originalText.Length; i++)
        {
            uiText.text += originalText[i];
            yield return new WaitForSeconds(delayBetweenLetters);
        }
    }
}



