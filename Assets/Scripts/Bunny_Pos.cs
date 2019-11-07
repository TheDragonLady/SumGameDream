using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny_Pos : MonoBehaviour
{
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

}
