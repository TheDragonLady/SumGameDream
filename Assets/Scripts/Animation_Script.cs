using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Player))]
public class Animation_Script : MonoBehaviour
{
    public Animator anim;
    public Player player;
    public SpriteRenderer sprite;

    private void Start()
    {
        sprite = anim.GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        GetComponent<Player>();
    }

    public void LookLeft()
    {
        sprite.flipX = false;
    }

    public void LookRight()
    {
        sprite.flipX = true;
    }



    public void PlayRun()
    {
        anim.SetFloat("Speed", 0.5f);
    }

    public void PlayIdle()
    {
        anim.SetFloat("Speed", 0);
    }

    public void Jumping()
    {
        if(player.velocity.y > 0f)
        {
            anim.SetBool("IsJumping", true);
        }
    }

    public void NotJumping()
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
        }
    }

    public void NotWallSliding()
    {
        anim.SetBool("WallHold", false);
    }

    public void WallJump()
    {
        anim.SetBool("WallHold", false);
        anim.SetBool("IsJumping", true);
    }

    public void Pushing()
    {
        anim.SetBool("pushing", true);
    }

    public void NotPushing()
    {
        anim.SetBool("pushing", false);
    }
}
