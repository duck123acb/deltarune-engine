using UnityEngine;

public enum Speaker
{
    Narrator,
    Susie,
    Ralsei,
    Toriel,
    Asgore
}

[System.Serializable]
public class DialogueLine
{
    public Speaker speaker = Speaker.Narrator;
    public SpeakerData speakerData;
    [TextArea]
    public string line;
}