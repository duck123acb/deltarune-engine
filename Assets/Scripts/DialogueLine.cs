using UnityEngine;

public enum Speaker
{
    Default, // narrator
    Susie,
    // Ralsei,
    // Knight // ??
}

[System.Serializable]
public class DialogueLine
{
    public Speaker speaker = Speaker.Default;
    public Sprite portrait;
    public AudioClip voiceClip;
    public string text;
}