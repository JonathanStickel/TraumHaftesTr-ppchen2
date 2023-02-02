using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGraphics : MonoBehaviour
{
    public PlayerMov player;
    public bool isFacingRight;
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    /*public void Flip()
    {
        if (isFacingRight)
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        else
            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y
    }*/
}
