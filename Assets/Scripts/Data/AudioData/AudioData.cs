using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "Audio/Audio Data")]
public class AudioData : ScriptableObject
{
    [Header("BGM")]
    public AudioClip bgm;
}