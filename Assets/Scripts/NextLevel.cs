using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Text cantPassLevelText;

    private Manager manager;
    private Timer timer;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        manager = GameObject.Find("GameManager").GetComponent<Manager>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        bool playerCanPassLevel = manager.canPassLevel;
        if (collider.gameObject.tag == "Player" && playerCanPassLevel)
        {
            manager.LoadLevel();
            PlayerPrefs.SetFloat("saveActualTime", timer.actualTime);
            Debug.Log("Tries every level: " + PlayerPrefs.GetInt("gameTries"));
        }
        else if (collider.gameObject.tag == "Player" && !playerCanPassLevel && cantPassLevelText != null)
        {
            StartCoroutine("ShowCantPassText");
        }
    }

    IEnumerator ShowCantPassText()
    {
        cantPassLevelText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        cantPassLevelText.gameObject.SetActive(false);
    }
}
