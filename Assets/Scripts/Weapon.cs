using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Weapon : MonoBehaviour
{
    public enum WeaponType
    {
        Hamburguer,
        Bread
    }

    #region Public Variables
    public Transform firePoint;
    public GameObject hambBulletPrefab;
    public GameObject playerHamburguesa;
    public GameObject playerPan;
    public GameObject playerGelatina;
    public Animator anim;
    public bool canAttack;
    public bool defendingMode;
    public Manager manager;
    public WeaponType weaponType;
    #endregion

    private string activeScene;

    void Start()
    {
        canAttack = true;
        playerHamburguesa.SetActive(true);
        playerPan.SetActive(false);
        playerGelatina.SetActive(false);
        anim = GetComponent<Animator>();
        activeScene = SceneManager.GetActiveScene().name.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeScene == "Level01" || activeScene == "Level02" || activeScene == "Level03")
        {
            if (Input.GetKeyDown(KeyCode.Z) && canAttack && !manager.pause)
            {
                Shoot();
                playerHamburguesa.SetActive(true);
                playerPan.SetActive(false);
                anim.SetTrigger("hamburguesa");
                weaponType = WeaponType.Hamburguer;
            }

            if (activeScene == "Level02" || activeScene == "Level03")
            {
                if (Input.GetKeyDown(KeyCode.X) && canAttack && !manager.pause)
                {
                    playerHamburguesa.SetActive(false);
                    playerPan.SetActive(true);
                    anim.SetTrigger("pan");
                    weaponType = WeaponType.Bread;
                }
            }

            if (activeScene == "Level03")
            {
                if (Input.GetKey(KeyCode.C) && !manager.pause)
                {
                    playerGelatina.SetActive(true);
                    canAttack = false;
                    defendingMode = true;
                }
                else
                {
                    playerGelatina.SetActive(false);
                    canAttack = true;
                    defendingMode = false;
                }
            }
        }
    }
    void Shoot()
    {
        Instantiate(hambBulletPrefab, firePoint.position, firePoint.rotation);
    }
}
