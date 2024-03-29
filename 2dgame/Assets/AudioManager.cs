using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private AudioClip music1;
    [SerializeField] private AudioClip music2;
    [SerializeField] private AudioClip music3;
    [SerializeField] private AudioClip music4;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        musicSource.clip = music1;
        musicSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        string actual = SceneManager.GetActiveScene().name;
        if (actual == "Escena2-MuseoNoche" || actual == "Escena6-MuseoNoche2" || actual == "Epilogo-Museo")
        {
            musicSource.clip = music4;
            musicSource.pitch = 0.45f;
        }
        else
        {
            musicSource.pitch = 1f;
            if (actual == "MenuInicial")
            {
                musicSource.clip = music1;
            }
            else if (actual == "AngelMinijuego")
            {
                musicSource.clip = music4;
            }
            else if (actual == "JoelMinijuego")
            {
                musicSource.clip = music3;
            }
            else
            {
                musicSource.clip = music2;
            }
        }
        if (!musicSource.isPlaying) {
            musicSource.Play();
        }



    }
}
