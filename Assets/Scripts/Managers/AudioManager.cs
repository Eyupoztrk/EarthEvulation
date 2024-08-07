using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private void Awake() {
         instance = this;
    }
    public AudioSource clickSound;
    public AudioSource successSound;

    public void PlaySound(AudioSource sound)
    {
        sound.Play();
    }
}
