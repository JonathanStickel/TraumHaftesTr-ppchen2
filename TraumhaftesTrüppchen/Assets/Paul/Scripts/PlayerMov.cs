using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private float xMov;
    // private float yMov;
    public float speed;
    public Rigidbody2D rb;
    public float normaljumpForce;
    public float coyotejumpForce;
    public bool grounded;
    public LayerMask groundLayer;
    // private float highestJumpPos;
    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {







        Debug.Log(rb.velocity);
        RaycastHit2D[] groundCheck = Physics2D.RaycastAll(transform.position, Vector3.down, 1.05f, groundLayer);

        if (groundCheck.Length > 0)
        {
            grounded = true;
            speed = 400;
        }
        else
        {
            grounded = false;
            speed = 300;
        }


        xMov = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.E))
        {

        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            //highestJumpPos = transform.position.y;
            rb.AddForce(Vector3.up * normaljumpForce);
            grounded = false;
            StartCoroutine(JumpRoutine());
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            rb.drag = 0.6f;

        }
        if (xMov == 0 && grounded == true)
        {
            rb.drag = 6f;

        }

        if (grounded != true)
        {
            rb.drag = 0.1f;
        }
        if (grounded == true)
        {
            speed = 400;
        }
        if (grounded == false && rb.velocity.y <= 0 && rb.velocity.y >= -1 && Input.GetKeyDown(KeyCode.Space))
        {

            //highestJumpPos = transform.position.y;
            rb.AddForce(Vector3.up * coyotejumpForce);
            grounded = false;
            StartCoroutine(JumpRoutine());
        }
    }
    private void FixedUpdate()
    {

        rb.AddForce(new Vector2(xMov, 0) * speed * Time.deltaTime);
        //transform.position += new Vector3(xMov, 0, 0) * Time.deltaTime * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }

    }
    IEnumerator JumpRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 3f;


    }
}
