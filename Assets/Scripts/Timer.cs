using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float actualTime = 0.0f;
    public bool finish = false;
    
    private string activeScene;

    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene().name.ToString();
        if (activeScene == "Level01")
            actualTime = 0.0f;
        else if (activeScene == "Level02")
            actualTime = PlayerPrefs.GetFloat("saveActualTime");
        else if (activeScene == "Level03")
            actualTime = PlayerPrefs.GetFloat("saveActualTime");
    }

    // Update is called once per frame
    void Update()
    {
        if (finish)
            return;

        actualTime += Time.deltaTime;

        string minutes = ((int) actualTime / 60).ToString();
        string seconds = (actualTime % 60).ToString("00.00");

        timerText.text = minutes + ":" + seconds;
    }
}
