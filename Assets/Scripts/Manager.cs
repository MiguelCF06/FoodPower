using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject panel;
    public bool pause;
    public bool gameOver;
    public GameObject PauseMenu;
    public GameObject GameOver;
    public int dieCounter = 0;
    public Text enemies;
    public Image enemigos;
    // Start is called before the first frame update
    void Start()
    {
        enemigos.color = Color.white;
        dieCounter = 0;
        Time.timeScale = 1;
        panel.SetActive(true);
        StartCoroutine("destroyBullet");
        gameOver = false;
        pause = false;
        PauseMenu.SetActive(false);
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemies.text = dieCounter.ToString() + "/25";
        if (Input.GetKeyDown(KeyCode.P) && !gameOver)
        {
            PausarJuego();
        }
        if (dieCounter >= 25)
        {
            enemigos.color = Color.green;
        }
    }

    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(2f);
        panel.SetActive(false);
    }

    public void PausarJuego()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pause = true;
            PauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pause = false;
            PauseMenu.SetActive(false);
        }
    }
    public void SetGameOver()
    {
        Time.timeScale = 0;
        pause = true;
        gameOver = true;
        GameOver.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeB()
    {
        Time.timeScale = 1;
        pause = false;
        PauseMenu.SetActive(false);
    }
}
