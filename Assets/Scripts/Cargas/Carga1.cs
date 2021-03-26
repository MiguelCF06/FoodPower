using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carga1 : MonoBehaviour
{
   public void LoadLevel1()
    {
        SceneManager.LoadScene("Level01");
        Time.timeScale = 1;
    }
}
