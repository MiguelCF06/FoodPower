using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject panel;
    public bool pause;
    public bool gameOver;
    public GameObject PauseMenu;
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.P) && !gameOver)
        {
            PausarJuego();
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
}
