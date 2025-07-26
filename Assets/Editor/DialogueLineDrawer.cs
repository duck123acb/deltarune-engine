using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(DialogueLine))]
public class DialogueLineDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        // text label
        Rect textLabelRect = new(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);
        EditorGUI.LabelField(textLabelRect, "Text");

        // textbox
        SerializedProperty textProp = property.FindPropertyRelative("text");
        position.height = EditorGUIUtility.singleLineHeight * 4;
        EditorGUI.PropertyField(position, textProp, GUIContent.none);

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight * 8;
    }
}
