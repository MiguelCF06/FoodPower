using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    AudioSource  audioSource;
    public AudioClip pauseSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 1f);
        AudioListener.volume = slider.value;
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
    }

    public void PlayPause()
    {
        audioSource.PlayOneShot(pauseSound);
    }
}
