using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundKlowBowl : MonoBehaviour
{

    public AudioSource AudioSource;
    private static SoundKlowBowl _Instance;
    public static SoundKlowBowl Instance { get { return _Instance; } }
    private void Awake()
    {
        if (_Instance != null) { Debug.LogWarning(TagTemplate.OnlyOneExistsObject+"SoundKlowBowl"); return; }
        SoundKlowBowl._Instance = this;
    }
    public AudioClip KnockBowlClip;
    public void PlaySound()
    {
        AudioSource.PlayOneShot(KnockBowlClip);
    }
   
}
