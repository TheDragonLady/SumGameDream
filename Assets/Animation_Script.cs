using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Script : MonoBehaviour
{
    public Animator anim;



    // Update is called once per frame
    void Update()
    {

    }

    public void PlayRun()
    {
        anim.SetFloat("Speed", 0.5f);
    }

    public void PlayIdle()
    {
        anim.SetFloat("Speed", 0);
    }

    public void IsJumping()
    {
        anim.SetBool("IsJumping", true);
    }




}
