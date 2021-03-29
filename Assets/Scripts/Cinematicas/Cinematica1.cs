using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematica1 : MonoBehaviour
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
    }
    
    public void LoadScene()
    {
        SceneManager.LoadScene("Carga2");
    }
}
