using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomPropertyDrawer(typeof(DialogueLine))]
public class DialogueLineDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty speakerNameProp = property.FindPropertyRelative("speaker");
        SerializedProperty lastSpeakerNameProp = property.FindPropertyRelative("lastSpeaker");
        SerializedProperty portraitProp = property.FindPropertyRelative("portrait");
        SerializedProperty voiceClipProp = property.FindPropertyRelative("voiceClip");
        SerializedProperty lineProp = property.FindPropertyRelative("text");
        SerializedProperty delayProp = property.FindPropertyRelative("delayMS");

        float lineHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

        Rect speakerRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        Rect portraitRect = new Rect(position.x, position.y + lineHeight, position.width, EditorGUIUtility.singleLineHeight);
        Rect voiceClipRect = new Rect(position.x, position.y + lineHeight * 2, position.width, EditorGUIUtility.singleLineHeight);
        Rect lineRect = new Rect(position.x, position.y + lineHeight * 3, position.width, EditorGUIUtility.singleLineHeight * 3);
        Rect delayRect = new Rect(position.x, position.y + lineHeight * 6, position.width, EditorGUIUtility.singleLineHeight);

        EditorGUI.PropertyField(speakerRect, speakerNameProp);

        Speaker currentSpeaker = (Speaker)speakerNameProp.enumValueIndex;
        Speaker lastSpeaker = (Speaker)lastSpeakerNameProp.enumValueIndex;

        if (currentSpeaker != lastSpeaker)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>($"Speakers/{currentSpeaker}/spritesheet");
            Sprite portrait = sprites.FirstOrDefault(s => s.name == "default");
            AudioClip clip = Resources.Load<AudioClip>($"Speakers/{currentSpeaker}/speak");

            portraitProp.objectReferenceValue = portrait;
            voiceClipProp.objectReferenceValue = clip;

            lastSpeakerNameProp.enumValueIndex = speakerNameProp.enumValueIndex;
        }

        EditorGUI.PropertyField(portraitRect, portraitProp);
        EditorGUI.PropertyField(voiceClipRect, voiceClipProp);
        EditorGUI.PropertyField(delayRect, delayProp);

        lineProp.stringValue = EditorGUI.TextArea(lineRect, lineProp.stringValue);

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // return EditorGUIUtility.singleLineHeight * 10; // debugging
        return EditorGUIUtility.singleLineHeight * 7.5f + EditorGUIUtility.standardVerticalSpacing; // this crashed unity?????? uhh if it does it again ima tweak out
    }
}
