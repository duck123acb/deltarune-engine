using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class Textbox : MonoBehaviour
{
    public event Action OnFinishedLine;

    public bool isDone = false;
    [SerializeField] Vector2 textPosWithPortrait;
    [SerializeField] Vector2 textPosWithoutPortrait;


    DialogueLine currentLine;
    int charactersSinceLastSound = 0;
    int index = 0;
    float timer = 0f;

    TextMeshProUGUI dialogueText;
    [SerializeField] Image portraitImage;

    void Awake()
    {
        dialogueText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void PlayTypingSound(AudioClip clip)
    {
        AudioManager.instance.PlaySFX(currentLine.voiceClip);
    }

    public void LoadLine(DialogueLine line)
    {
        isDone = false;
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

        index = 0;
    }

    void UpdateTextbox(char c)
    {
        dialogueText.text += c;

        if (char.IsLetterOrDigit(c))
        {
            charactersSinceLastSound++; // could replace with a modulo
            if (charactersSinceLastSound >= currentLine.charsPerSound)
            {
                PlayTypingSound(currentLine.voiceClip);
                charactersSinceLastSound = 0;
            }
        }

        isDone = dialogueText.text == currentLine.text;
    }

    void Update()
    {
        if (!gameObject.activeSelf || isDone) return;

        timer += Time.deltaTime * 1000f;
        if (timer < currentLine.delayMS) return;

        char c = currentLine.text[index];
        UpdateTextbox(c);
        index++;
        timer -= currentLine.delayMS;
    }

    #region PLAYER_INPUT
    public void AdvanceDialogueTrigger(InputAction.CallbackContext context)
    {
        if (context.performed && isDone)
        { 
            OnFinishedLine?.Invoke();
        }
   }
    #endregion
}
