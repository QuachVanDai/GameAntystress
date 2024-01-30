using System.Collections;
using UnityEngine;

public class SoundMoveAroundBowl : MonoBehaviour
{
    public AudioSource AudioSource;
    private static SoundMoveAroundBowl _Instance;
    public static SoundMoveAroundBowl Instance { get { return _Instance; } }
    private void Awake()
    {
        if (_Instance != null) { Debug.LogWarning(TagTemplate.OnlyOneExistsObject+"SoundMoveAroundBowl "); return; }
        SoundMoveAroundBowl._Instance = this;
    }
    private void Start()
    {
        AudioSource.volume = 0;
    }
    public AudioClip MoveAroundBowlClip;
    public void PlaySound()
    {
        AudioSource.PlayOneShot(MoveAroundBowlClip);
    }
    public void StopSound()
    {
        StopAllCoroutines();
        AudioSource.Stop();
    }
    public  void IncreaseVolume()
    {
        StopAllCoroutines();
        StartCoroutine(IncreaseVolume(0));
    }
    private IEnumerator IncreaseVolume(float number)
    {
        AudioSource.Play();
        AudioSource.volume=number;
        while (number >= 0 && number <= 1)
        {
            AudioSource.volume += 0.05f;
            yield return new WaitForSeconds(0.1f);
            number += 0.1f;
        }
    }
    private IEnumerator DecreaseVolume(float number)
    {
        AudioSource.volume = number;
        while (number >= 0 && number <= 1)
        {
            AudioSource.volume -= 0.1f;
            yield return new WaitForSeconds(0.1f);
            number -= 0.1f;
        }
        AudioSource.Stop();
    }
    public  void DecreaseVolume()
    {
        StartCoroutine(DecreaseVolume(1));
    }
}
