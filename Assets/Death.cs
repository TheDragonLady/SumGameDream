using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
  //  [SerializeField] private Transform player;
    [SerializeField] Transform spawnPoint;

 
    //make sure to put the respawn in line with the rest of the platform,otherwise player will become "invisible"
    private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.transform.CompareTag("Player"))
        collision.transform.position = spawnPoint.position;

     
    }
} 
