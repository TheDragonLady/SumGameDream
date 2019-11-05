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




}
