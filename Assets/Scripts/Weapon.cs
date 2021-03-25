using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject hambBulletPrefab;
    public GameObject playerHamburguesa;
    public GameObject playerPan;
    public Animator anim;

    void Start()
    {
        playerHamburguesa.SetActive(true);
        playerPan.SetActive(false);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();
            playerHamburguesa.SetActive(true);
            playerPan.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            playerHamburguesa.SetActive(false);
            playerPan.SetActive(true);
            anim.SetTrigger("pan");
        }
    }

    void Shoot()
    {
        Instantiate(hambBulletPrefab, firePoint.position, firePoint.rotation);
    }
}
