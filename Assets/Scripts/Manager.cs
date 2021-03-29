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
    public bool canPassLevel;
    public GameObject PauseMenu;
    public GameObject GameOver;
    public int dieCounter = 0;
    public Text enemies;
    public Image enemigos;
    public int totalOfEnemiesToKill;
    public string activeScene;
    public Sound sound;
    public AudioClip pauseSound;
    public AudioClip gameoverSound;
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
        canPassLevel = false;
        PauseMenu.SetActive(false);
        GameOver.SetActive(false);
        activeScene = SceneManager.GetActiveScene().name.ToString();
        sound = FindObjectOfType<Sound>();

        if (activeScene == "Level01")
            totalOfEnemiesToKill = 25;
        else if (activeScene == "Level02")
            totalOfEnemiesToKill = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeScene == "Level01")
            enemies.text = dieCounter.ToString() + "/25";
        else if (activeScene == "Level02")
            enemies.text = dieCounter.ToString() + "/30";
        else if (activeScene == "Level03")
        {
            enemigos.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.P) && !gameOver)
        {
            PausarJuego();
        }
        if (dieCounter >= totalOfEnemiesToKill)
        {
            enemigos.color = Color.green;
            canPassLevel = true;
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
            sound.PlaySound(pauseSound);
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
        sound.PlaySound(gameoverSound);
        Time.timeScale = 0;
        pause = true;
        gameOver = true;
        GameOver.SetActive(true);
    }

    public void LoadLevel()
    {
        // load the nextlevel
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level01");
    }
}
