using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carga3 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("fade1");
    }
    IEnumerator fade1()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("Level02");
        Time.timeScale = 1;
    }
}
