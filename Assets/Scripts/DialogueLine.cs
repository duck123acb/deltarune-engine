using UnityEngine;

public enum Speaker
{
    Narrator,
    Susie,
    // Ralsei,
    // Knight // ??
}

[System.Serializable]
public class DialogueLine
{
    public Speaker speaker = Speaker.Narrator;
    public Sprite portrait;
    public AudioClip voiceClip;
    public string text;
}