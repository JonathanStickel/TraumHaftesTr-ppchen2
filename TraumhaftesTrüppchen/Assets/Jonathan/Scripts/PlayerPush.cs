using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerPush : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask pushMask;

    public PlayerMov player;

    GameObject box;

    public Animator playerAnimator;

    public Transform Left;
    public Transform Right;
    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hitRight = Physics2D.Raycast(Left.position, Vector2.right * transform.localScale.x, distance, pushMask);
        RaycastHit2D hitRightDown = Physics2D.Raycast(Right.position, Vector2.right * transform.localScale.x, distance, pushMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(Left.position, Vector2.left * transform.localScale.x, distance, pushMask);
        RaycastHit2D hitLeftDown = Physics2D.Raycast(Left.position, Vector2.left * transform.localScale.x, distance, pushMask);


        if((hitLeft.collider != null || hitRight.collider != null || hitRightDown.collider != null|| hitLeftDown.collider != null) && Input.GetMouseButtonDown(0))
        {
            if(hitLeft.collider!= null && Input.GetMouseButtonDown(0))
            box = hitLeft.collider.gameObject;
            if(hitRight.collider!= null)
            box = hitRight.collider.gameObject;
            player.speed = 1000;
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            playerAnimator.SetBool("Pushing", true);
        }

        if(Input.GetMouseButtonUp(0))
        {
            player.speed = player.startSpeed;
            if(box != null)
            box.GetComponent<FixedJoint2D>().enabled = false;
            playerAnimator.SetBool("Pushing", false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(Left.position, new Vector2(transform.position.x, transform.position.y) + Vector2.right * transform.localScale.x * distance);
        Gizmos.DrawLine(Left.position, new Vector2(transform.position.x, transform.position.y) + Vector2.left * transform.localScale.x * distance);
    }
}
