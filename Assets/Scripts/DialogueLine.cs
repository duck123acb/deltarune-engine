using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public SpeakerData speaker;
    [TextArea]
    public string line;
}