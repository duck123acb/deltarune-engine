using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomPropertyDrawer(typeof(DialogueLine))]
public class DialogueLineDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty lineProp = property.FindPropertyRelative("text");
        position.height = EditorGUIUtility.singleLineHeight * 4;
        EditorGUI.PropertyField(position, lineProp);

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // Only need one line height
        return EditorGUIUtility.singleLineHeight * 5;
    }
}
