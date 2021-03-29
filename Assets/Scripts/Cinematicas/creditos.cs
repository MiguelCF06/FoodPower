using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditos : MonoBehaviour
{
    public GameObject fade;

   void Start() 
   {
       StartCoroutine("startscene");
   }
   IEnumerator startscene()
    {
        yield return new WaitForSeconds(60);
        clickbutton();
    }

    public void clickbutton()
    {
        fade.SetActive(true);
        StartCoroutine("fade1");
    }
    IEnumerator fade1()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainMenu");
    }
}
