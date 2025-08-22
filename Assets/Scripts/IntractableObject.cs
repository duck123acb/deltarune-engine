using System;
using UnityEngine;

public class IntractableObject : MonoBehaviour
{
    public event Action<DialogueLine[]> OnInteract;

    [SerializeField] DialogueLine[] lines;

    public void Interact()
    {
        OnInteract?.Invoke(lines);
    }
}
