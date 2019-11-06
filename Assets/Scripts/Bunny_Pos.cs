using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Bunny_Pos : MonoBehaviour
{

    public PlayerInput player;

    public Transform con;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = con.position;
    }

    void Bunny_Move()
    {
        if(player.directionalInput.x == -1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (player.directionalInput.x == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
