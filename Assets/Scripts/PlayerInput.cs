using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void FixedUpdate()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

        //Sprinting Character
        if(Input.GetKey(KeyCode.LeftShift))
        {
            player.walkSpeed = player.sprintSpeed;
        }
        else
        {
            player.walkSpeed = player.walkSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.walkSpeed = 6f;
        }

        if(Input.GetButtonDown ("Jump"))
        {
            player.OnJumpInputDown();
        }
        if (Input.GetButtonUp("Jump"))
        {
            player.OnJumpInputUp();
        }
    }
}
