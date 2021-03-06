using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematica2 : MonoBehaviour
{
    public GameObject fade;
   void Start() 
   {
       fade.SetActive(false);
       StartCoroutine("fade1");
   }
   IEnumerator fade1()
    {
        yield return new WaitForSeconds(2);
        fade.SetActive(false);
        StartCoroutine("cinematic");
    }
    IEnumerator cinematic()
    {
        yield return new WaitForSeconds(7);
        fade.SetActive(false);
        StartCoroutine("loadscene");
    }
    IEnumerator loadscene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("creditos");
    }
}
