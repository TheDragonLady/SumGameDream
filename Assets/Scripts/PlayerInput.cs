using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    public Animator animator;
    Player player;

    bool jump = false;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void FixedUpdate()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

        //Sprinting Character
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.walkSpeed = player.sprintSpeed;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.walkSpeed = 6f;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
