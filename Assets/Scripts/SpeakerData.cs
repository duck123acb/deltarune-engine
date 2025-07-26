using UnityEngine;

[CreateAssetMenu(menuName = "Speaker Data")]
public class SpeakerData : ScriptableObject
{
    public string displayName;
    public Sprite portrait;
    public AudioClip voiceClip;
    public Font dialogueFont;
}