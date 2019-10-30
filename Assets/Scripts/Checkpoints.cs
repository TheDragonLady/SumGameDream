using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{

    private Game_Master gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Master>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            gm.lastCheckPos = transform.position;
        }
    }
}
