using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomPropertyDrawer(typeof(DialogueLine))]
public class DialogueLineDrawer : PropertyDrawer
{
    private string lastSpeakerName = null;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty speakerNameProp = property.FindPropertyRelative("speaker");
        SerializedProperty portraitProp = property.FindPropertyRelative("portrait");
        SerializedProperty voiceClipProp = property.FindPropertyRelative("voiceClip");
        SerializedProperty lineProp = property.FindPropertyRelative("text");

        float lineHeight = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

        Rect speakerRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        Rect portraitRect = new Rect(position.x, position.y + lineHeight, position.width, EditorGUIUtility.singleLineHeight);
        Rect voiceClipRect = new Rect(position.x, position.y + lineHeight * 2, position.width, EditorGUIUtility.singleLineHeight);
        Rect lineRect = new Rect(position.x, position.y + lineHeight * 3, position.width, EditorGUIUtility.singleLineHeight * 3);

        EditorGUI.PropertyField(speakerRect, speakerNameProp);

        string speakerName = speakerNameProp.enumNames[speakerNameProp.enumValueIndex];
        if (lastSpeakerName != speakerName)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>($"Speakers/{speakerName}/spritesheet");
            Sprite portrait = sprites.FirstOrDefault(s => s.name == "default");
            AudioClip clip = Resources.Load<AudioClip>($"Speakers/{speakerName}/speak");

            portraitProp.objectReferenceValue = portrait;
            voiceClipProp.objectReferenceValue = clip;

            lastSpeakerName = speakerName;
        }

        EditorGUI.PropertyField(portraitRect, portraitProp);
        EditorGUI.PropertyField(voiceClipRect, voiceClipProp);

        lineProp.stringValue = EditorGUI.TextArea(lineRect, lineProp.stringValue);

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // return EditorGUIUtility.singleLineHeight * 10; // debugging
        return EditorGUIUtility.singleLineHeight * 6.2f + EditorGUIUtility.standardVerticalSpacing; // this crashed unity?????? uhh if it does it again ima tweak out
    }
}
