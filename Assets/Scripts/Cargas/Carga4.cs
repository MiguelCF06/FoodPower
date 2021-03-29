using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carga4 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("fade1");
    }
    IEnumerator fade1()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Level03");
        Time.timeScale = 1;
    }
}
