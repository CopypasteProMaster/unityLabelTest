using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogChoicesWithButtons : MonoBehaviour
{
    public Text dialogText;
    public Button yesButton;
    public Button noButton;
    public float cps = 2.0f; // Clicks Per Second for buttons

    private void Start()
    {
        dialogText.text = "Hello player...\nAre you ready to play?";

        StartCoroutine(AnimateButtonsPopOut());
    }

    private IEnumerator AnimateButtonsPopOut()
    {
        Button[] buttons = { yesButton, noButton };
        foreach (Button button in buttons)
        {
            Vector3 originalScale = button.transform.localScale;
            button.transform.localScale = Vector3.zero;

            float elapsedTime = 0f;
            while (elapsedTime < 1f / cps)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime * cps;
                button.transform.localScale = Vector3.Lerp(Vector3.zero, originalScale, t);
                yield return null;
            }

            button.transform.localScale = originalScale;
        }
    }

    private void ChooseYes()
    {
        dialogText.text = "You clicked yes!\nThis is text 1 you clicked yes.";
    }

    private void ChooseNo()
    {
        dialogText.text = "You clicked no!\nReally?";
    }
}

