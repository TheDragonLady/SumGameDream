using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
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

    public void Update()
    {
        boxDetector = transform.position;
        boxDetector.x += width;

        RaycastHit2D hit = Physics2D.Raycast(boxDetector, Vector2.right, distance, boxMask);
        Debug.Log(hit.collider);

        if (hit.collider != null && hit.collider.tag == "Pushable" && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("button is pressed");
            box = hit.collider.gameObject;

            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<BoxPull>().beingPushed = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            box.GetComponent<FixedJoint2D>().autoConfigureConnectedAnchor = false;
            GetComponent<RaycastController>().collisionMask = LayerMask.GetMask("Obstacle");

        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<BoxPull>().beingPushed = false;
            GetComponent<RaycastController>().collisionMask = LayerMask.GetMask("Obstacle", "Default");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(boxDetector, (Vector2)transform.position + Vector2.right * distance);
    }
    
    //void DisableMask()
    //{
    //    gameObject.GetComponent<RaycastController>().collisionMask = LayerMask.GetMask("Default");
    //}
}
