using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControlMusica : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void VolMus (float sliderMus)
    {
        audioMixer.SetFloat("VolumenMus", Mathf.Log10(sliderMus)*20);
    }
}
