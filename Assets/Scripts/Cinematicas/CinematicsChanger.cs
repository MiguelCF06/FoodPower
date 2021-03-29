using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicsChanger : MonoBehaviour
{
    public GameObject[] cinematics;
    
    private int lengthCinematics;
    private int actualIndex;
    private Cinematica1 managerCinematicas;
    
    // Start is called before the first frame update
    void Start()
    {
        actualIndex = 0;
        lengthCinematics = cinematics.Length;
        cinematics[actualIndex].SetActive(true);
        managerCinematicas = GameObject.Find("GameManager").GetComponent<Cinematica1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeCinematic();
        }
    }

    void ChangeCinematic()
    {
        cinematics[actualIndex].SetActive(false);
        actualIndex += 1;
        if (actualIndex <= lengthCinematics - 1)
            cinematics[actualIndex].SetActive(true);
        else
            managerCinematicas.LoadScene();
    }
}
