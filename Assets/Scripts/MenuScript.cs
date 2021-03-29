using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Animator anim;
    AudioSource audioSource;
    public GameObject panel;
    public GameObject all;
    public GameObject city;

    void Start() 
    {
        Time.timeScale = 1;
        city.SetActive(true);
        all.SetActive(true);
        panel.SetActive(false);    
    }
    public void PressButton()
    {
        anim.SetTrigger("fade");
        panel.SetActive(true);
    }
    public void LoadLevel()
    {
        city.SetActive(false);
        all.SetActive(false);
        SceneManager.LoadScene("Carga1");
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
