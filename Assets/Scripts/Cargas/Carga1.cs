using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carga1 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("fade1");
    }
    IEnumerator fade1()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Cinematica1");
        Time.timeScale = 1;
    }
}
