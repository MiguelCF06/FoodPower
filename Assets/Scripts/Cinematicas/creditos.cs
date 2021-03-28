using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditos : MonoBehaviour
{
   void Start() 
   {
       StartCoroutine("fade1");
   }
   IEnumerator fade1()
    {
        yield return new WaitForSeconds(12);
        SceneManager.LoadScene("MainMenu");
    }
}
