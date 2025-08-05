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
    public int delayMS = 2000;
    public int charsPerSound = 3;
    public bool done = false;

    [HideInInspector] public Speaker lastSpeaker = Speaker.Default; // for the inspector
}