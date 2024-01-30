using UnityEngine;

public class SoundPaperRoll : MonoBehaviour
{
    public AudioSource AudioSource;
    private static SoundPaperRoll _Instance;
    public static SoundPaperRoll Instance { get { return _Instance; } }
    private void Awake()
    {
        if (_Instance != null) { Debug.LogWarning(TagTemplate.OnlyOneExistsObject + "SoundPaperRoll "); return; }
        SoundPaperRoll._Instance = this;
    }
    public AudioClip SoundPaperRollClip;
    public void PlaySound()
    {
        AudioSource.PlayOneShot(SoundPaperRollClip);
    }
}
