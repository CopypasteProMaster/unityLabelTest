using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LetterPopAnimation : MonoBehaviour
{
    public Text uiText;
    public float popSpeed = 1.0f;

    private void Start()
    {
        StartCoroutine(PopLetters());
    }

    private IEnumerator PopLetters()
    {
        foreach (char letter in uiText.text)
        {
            Text letterObject = Instantiate(uiText, uiText.transform.parent);
            letterObject.text = letter.ToString();
            letterObject.rectTransform.anchoredPosition += Vector2.up * 100f; // Adjust the pop-out distance

            float elapsedTime = 0f;
            Vector2 originalPosition = letterObject.rectTransform.anchoredPosition;

            while (elapsedTime < 1f / popSpeed)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime * popSpeed;
                letterObject.rectTransform.anchoredPosition = Vector2.Lerp(originalPosition, originalPosition + Vector2.up * 100f, t);
                yield return null;
            }

            Destroy(letterObject.gameObject);
            yield return new WaitForSeconds(0.2f); // Delay between letter pops
        }
    }
}

