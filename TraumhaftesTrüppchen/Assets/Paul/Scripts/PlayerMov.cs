using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMov : MonoBehaviour
{
    public static PlayerMov _instance;

    public static PlayerMov _Instance
    {
        get
        {
            return _instance;
        }
    }
    public float xMov;
    // private float yMov;
    public float speed = 400;
    public float startSpeed;
    private float airSpeed;
    public Rigidbody2D rb;
    public float normaljumpForce;
    public float coyotejumpForce;
    [SerializeField]
    public bool grounded;
    public LayerMask groundLayer;

    public bool isPushing;
    public bool isMoving;

    public Animator playerAnimator;
    public float maxVelocity;
    // private float highestJumpPos;
    // Start is called before the first frame update
    void Start()
    {
        airSpeed = speed * 0.75f;
        startSpeed = speed;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.velocity);
        RaycastHit2D[] groundCheck = Physics2D.RaycastAll(transform.position, Vector3.down, 1.05f, groundLayer);

        if (groundCheck.Length > 0)
        {
            grounded = true;
            playerAnimator.SetBool("Jumping", false);
        }
        else
        {
            grounded = false;
            speed = airSpeed;
        }

        xMov = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            //highestJumpPos = transform.position.y;r
            //rb.velocity = Vector2.zero;

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
            playerAnimator.SetBool("Jumping", true);
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

        //PushPullCheck();
        DoAnimations();

        if(rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }

        AudioStuff();
    }

    public void DoAnimations()
    {
        if (rb.velocity.x != 0)
        {
            playerAnimator.SetBool("Moving", true);

            isMoving = true;
        }
        else
        {
            playerAnimator.SetBool("Moving", false);
            isMoving = false;
        }

    }

    /*public GameObject LeftColl;
    public GameObject RightColl;

    public void PushPullCheck()
    {
        
        

        if(isPushing)
        {
            speed = pushSpeed;
        }
        else if(grounded)
        {
            speed = startSpeed;
        }
    }*/

    private void FixedUpdate()
    {
        //rb.velocity = new Vector3(xMov * speed, rb.velocity.y, 0) * Time.fixedDeltaTime;
        rb.AddForce(new Vector2(xMov, 0) * speed * Time.deltaTime);
        //transform.position += new Vector3(xMov, 0, 0) * Time.deltaTime * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.CompareTag("Pushable"))
        {
            speed = startSpeed;
            grounded = true;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }

    }
    IEnumerator JumpRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 3f;


    }

    public AudioSource moving;
    public void AudioStuff()
    {
        if (isMoving && grounded)
            moving.Play();
        else
            moving.Stop();
    }
}
