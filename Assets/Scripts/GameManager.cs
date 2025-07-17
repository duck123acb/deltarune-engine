using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioClip music;

    void Awake()
    {
        Screen.SetResolution(640, 480, false);
    }

    void Start()
    {
        AudioManager.instance.PlayMusic(music);
    }
    
}
