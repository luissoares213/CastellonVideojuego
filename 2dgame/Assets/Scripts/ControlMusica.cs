using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControlMusica : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string nameSound;

    public void VolMus (float sliderMus)
    {
        audioMixer.SetFloat(nameSound, Mathf.Log10(sliderMus)*20);
    }
}
