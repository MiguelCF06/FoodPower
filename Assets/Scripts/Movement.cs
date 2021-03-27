using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Weapon weaponScript;
    float horizontalMove = 0f;
    bool jump = false;
    bool defenseMode;

    // Update is called once per frame
    void Update()
    {
        defenseMode = weaponScript.defendingMode;
        if (!defenseMode)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (!defenseMode)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
    }
}
