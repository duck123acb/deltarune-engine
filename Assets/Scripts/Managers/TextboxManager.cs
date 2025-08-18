using System;
using UnityEngine;

public class TextboxManager : MonoBehaviour
{
    public event Action StartedDialogue;
    public event Action EndedDialogue;

    Textbox textbox;

    DialogueLine[] lines;
    int currentIndex = 0;

    void Awake()
    {
        if (textbox == null)
            textbox = GetComponentInChildren<Textbox>();

        textbox.gameObject.SetActive(false);
        textbox.OnFinishedLine += ShowNextLine;
    }

    void OnEnable()
    {
        foreach (var intractable in FindObjectsByType<IntractableObject>(FindObjectsSortMode.None))
        {
            intractable.OnInteract += StartDialogue;
        }
    }

    void OnDisable()
    {
        foreach (var intractable in FindObjectsByType<IntractableObject>(FindObjectsSortMode.None))
        {
            intractable.OnInteract -= StartDialogue;
        }
    }

    void StartDialogue(DialogueLine[] dialogueLines)
    {
        if (dialogueLines == null || dialogueLines.Length == 0) return;

        StartedDialogue?.Invoke();

        lines = dialogueLines;
        currentIndex = 0;

        textbox.gameObject.SetActive(true);
        textbox.LoadLine(lines[currentIndex]);
    }

    void ShowNextLine()
    {
        currentIndex++;

        if (lines == null || currentIndex >= lines.Length)
        {

            EndedDialogue?.Invoke();
            textbox.gameObject.SetActive(false);
            lines = null;
            currentIndex = 0;
            return;
        }

        textbox.LoadLine(lines[currentIndex]);
    }
}
