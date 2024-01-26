using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundKeyboard : MonoBehaviour
{
    public AudioSource AudioSource;
    private static SoundKeyboard _Instance;
    public static SoundKeyboard Instance { get { return _Instance; } }
    private void Awake()
    {
        if (_Instance != null) { Debug.LogWarning(TagTemplate.OnlyOneExistsObject + "SoundKeyboard "); return; }
        SoundKeyboard._Instance = this;
    }
    public AudioClip[] SoundKeyboardClip;
    public void PlaySound()
    {
        int index = Random.Range(0, SoundKeyboardClip.Length);
        AudioSource.PlayOneShot(SoundKeyboardClip[index]);
    }
}
