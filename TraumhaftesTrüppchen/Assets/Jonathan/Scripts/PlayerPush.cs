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
    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, pushMask);

        if(hit.collider != null && Input.GetMouseButtonDown(0))
        {
            box = hit.collider.gameObject;
            player.speed = 1000;
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            playerAnimator.SetBool("Pushing", true);
        }

        if(Input.GetMouseButtonUp(0))
        {
            player.speed = player.startSpeed;
            box.GetComponent<FixedJoint2D>().enabled = false;
            playerAnimator.SetBool("Pushing", false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) + Vector2.right * transform.localScale.x * distance);
    }
}
