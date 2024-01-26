using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManage : MonoBehaviour
{
    public AudioSource m_AudioSource;
    public void PlaySound(AudioClip clip)
    {
        m_AudioSource.clip = clip;
        m_AudioSource.loop = true;
        m_AudioSource.volume = 1;
        m_AudioSource.Play();
    }

    public void StopSound()
    {
        m_AudioSource.Stop();
        m_AudioSource.loop=false;
    }
    public void ContinueSound()
    {
        m_AudioSource.Play();
    }
    public void PauseSound()
    {
        m_AudioSource.Pause();
    }
}
