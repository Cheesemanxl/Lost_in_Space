using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10;
    public float jumpForce = 3;
    private float moveInput;
    private bool faceRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public GameObject bullet;
    public Transform shootPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Movement()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (faceRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (faceRight == true && moveInput < 0)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

        if (!faceRight)
        {
            shootPoint.rotation = new Quaternion(0, 0, 180, 0);
        }
        else
        {
            shootPoint.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    void Shoot()
    {
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
    }
}
