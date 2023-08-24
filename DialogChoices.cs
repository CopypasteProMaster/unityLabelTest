using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogChoices : MonoBehaviour
{
    public Text dialogText;
     public Text uiText;
    public Button yesButton;
    public Button noButton;
    public float cps = 2.0f;

    private bool choiceMade = false;

    private void Start()
    {
       StartCoroutine(AnimateProgressively());
        
        yesButton.onClick.AddListener(ChooseYes);
        noButton.onClick.AddListener(ChooseNo);
    }

    private void ChooseYes()
    {
        if (!choiceMade)
        {
            choiceMade = true;
            dialogText.text = "You clicked yes!\nThis is text 1 you clicked yes.";
        }
    }

    private void ChooseNo()
    {
        if (!choiceMade)
        {
            choiceMade = true;
            dialogText.text = "You clicked no!\nReally?";
        }
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
