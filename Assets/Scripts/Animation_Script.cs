using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Animation_Script : MonoBehaviour
{
    public Animator anim;

    public Player player;


    // Update is called once per frame
    void Update()
    {
        GetComponent<Player>();
    }

    public void PlayRun()
    {
        anim.SetFloat("Speed", 0.5f);
    }

    public void PlayIdle()
    {
        anim.SetFloat("Speed", 0);
    }

    public void IsJumpingUp()
    {
        if(player.velocity.y > 0f)
        {
            anim.SetBool("IsJumping", true);
        }
    }

    public void IsJumpingDown()
    {
        if (player.velocity.y == 0f)
        {
            anim.SetBool("IsJumping", false);
        }
    }

    public void IsHolding()
    {
        if(player.wallSliding == true)
        {
            anim.SetBool("WallHold", true);
            anim.SetBool("IsJumping", false);
            anim.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void IsNotHolding()
    {
        anim.SetBool("WallHold", false);
        //anim.GetComponent<SpriteRenderer>().flipX = true;
    }

    public void WallJump()
    {
        anim.SetBool("WallHold", false);
        anim.GetComponent<SpriteRenderer>().flipX = true;
        anim.SetBool("IsJumping", true);
    }




}
