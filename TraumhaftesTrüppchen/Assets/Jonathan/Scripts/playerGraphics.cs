using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class playerGraphics : MonoBehaviour
{
    public Animator playerAnimator;

    public PlayerMov player;
    public bool isFacingRight;

    public Vector3 walkScale;
    private Vector3 normalScale;
    // Start is called before the first frame update
    void Start()
    {
        normalScale = transform.localScale;
    }
    public Rigidbody2D rb;
    // Update is called once per frame
    void Update()
    {
        if (player.xMov < 0 && !isFacingRight)
        {
            isFacingRight = true;
            Flip();
        }
        if (player.xMov > 0 && isFacingRight)
        {
            isFacingRight = false;
            Flip();
        }

        if (playerAnimator.GetBool("Moving") && !playerAnimator.GetBool("Pushing"))
        {
            transform.localScale = walkScale;
        }
        else
            transform.localScale = normalScale;

        if (!playerAnimator.GetBool("Pushing"))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);

            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);

            }
        }
    }
    public void Flip()
    {/*
        if (isFacingRight)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        else
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
        */
    }
}
