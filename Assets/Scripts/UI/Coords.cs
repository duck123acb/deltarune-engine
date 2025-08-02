using System;
using TMPro;
using UnityEngine;

public class Coords : MonoBehaviour
{
    [SerializeField] Transform obj;
    TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        double x = Math.Round(obj.position.x, 2);
        double y = Math.Round(obj.position.y, 2);

        String coords = $"x: {x}\ny: {y}";
        text.text = coords;
    }
}
