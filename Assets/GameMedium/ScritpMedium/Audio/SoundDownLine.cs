using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDownLine : MonoBehaviour
{
    public AudioSource AudioSource;
    private static SoundDownLine _Instance;
    public static SoundDownLine Instance { get { return _Instance; } }
    private void Awake()
    {
        if (_Instance != null) { Debug.LogWarning(TagTemplate.OnlyOneExistsObject +"SoundDownLine "); return; }
        SoundDownLine._Instance = this;
    }
    public AudioClip SoundDownLineClip;
    public void PlaySound()
    {
        AudioSource.PlayOneShot(SoundDownLineClip);
    }
}
