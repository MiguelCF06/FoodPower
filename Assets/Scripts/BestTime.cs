using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BestTime : MonoBehaviour
{
    public Text actualTimeText;
    public float actualTime;
    public Text bestTimeText;
    public float bestTime;

    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        actualTime = PlayerPrefs.GetFloat("saveActualTime");

        if (PlayerPrefs.GetInt("gameTries") == 0)
        {
            bestTime = actualTime;
            PlayerPrefs.SetFloat("bestTime", bestTime);
        }
        else
        {
            if (actualTime < bestTime)
            {
                bestTime = actualTime;
                PlayerPrefs.SetFloat("bestTime", bestTime);
            }
            else if (actualTime > bestTime)
            {
                bestTime = PlayerPrefs.GetFloat("bestTime");
            }
        }

        string minutes = ((int) actualTime / 60).ToString();
        string seconds = (actualTime % 60).ToString("00.00");

        string minutes2 = ((int) bestTime / 60).ToString();
        string seconds2 = (bestTime % 60).ToString("00.00");

        actualTimeText.text = "TU TIEMPO FUE:\n" + minutes + ":" + seconds;
        bestTimeText.text = "TU MEJOR TIEMPO:\n" + minutes2 + ":" + seconds2;


        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("CinematicaFinal");
    }
}
