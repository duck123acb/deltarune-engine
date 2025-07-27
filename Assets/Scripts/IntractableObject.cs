using UnityEngine;

public class IntractableObject : MonoBehaviour
{
    public DialogueLine[] lines;

    public void Interact()
    {
        foreach (DialogueLine dialogueLine in lines)
        {
            Debug.Log(dialogueLine.text);
        }
    }
}
