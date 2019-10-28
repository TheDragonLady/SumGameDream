using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask boxMask;
    public float width;
    public Vector2 boxDetector;

    GameObject box;

    private void Start()
    {
        
    }

    private void Update()
    {
        boxDetector = transform.position;
        boxDetector.x += width;

        RaycastHit2D hit = Physics2D.Raycast(boxDetector, Vector2.right, distance, boxMask);
        Debug.Log(hit.collider);

        if(hit.collider !=null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("button is pressed");
            box = hit.collider.gameObject;

            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(boxDetector, (Vector2)transform.position + Vector2.right * distance);
    }
}
