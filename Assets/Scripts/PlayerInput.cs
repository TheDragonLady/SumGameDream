using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    public Controller2D controller;
    public Animation_Script animScript;
    public Vector2 directionalInput;
    public Vector3 velocity;


    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);
        Vector3 jump = player.velocity;

        AnimateCharacter(directionalInput);
        GetButtons();
    }

    private void GetButtons()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.walkSpeed = player.sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.walkSpeed = 6f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            player.OnJumpInputDown();
        }

        if (Input.GetButtonUp("Jump"))
        {
            player.OnJumpInputUp();
        }
    }

    public void AnimateCharacter(Vector2 charactermovement)
    {
        if (charactermovement.x > 0 || charactermovement.x < 0) //&& not jumping
        {
            animScript.PlayRun();
        }
        else
        {
            animScript.PlayIdle();
        }

        if(charactermovement.y > 0)
        {
            animScript.IsJumping();
        }
    }


}
