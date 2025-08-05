using UnityEngine;
using UnityEngine.UI;

public class Textbox : MonoBehaviour
{
    [SerializeField] Vector2 textPosWithPortrait;
    [SerializeField] Vector2 textPosWithoutPortrait;


    DialogueLine currentLine;
    int charactersSinceLastSound = 0;

    Text dialogueText;
    Image portraitImage;

    public void LoadLine(DialogueLine line)
    {
        currentLine = line;

        dialogueText.text = "";

        if (line.portrait != null)
        {
            portraitImage.enabled = true;
            dialogueText.rectTransform.anchoredPosition = textPosWithPortrait;
            portraitImage.sprite = line.portrait;
        }
        else
        {
            portraitImage.enabled = false;
            dialogueText.rectTransform.anchoredPosition = textPosWithoutPortrait;
        }
    }

    void UpdateTextbox()
    {
        
    }
}
