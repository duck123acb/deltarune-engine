using UnityEngine;

public enum Speaker
{
    Narrator,
    Susie,
    Ralsei
}

[System.Serializable]
public class DialogueLine
{
    public Speaker speaker = Speaker.Narrator;
    public SpeakerData speakerData;
    // [TextArea]
    public string text;
}