using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 15;
    private int life = 128;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        life--;

        if (life < 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            Destroy(other.gameObject);
            Debug.Log("Hit emeny");
        }
    }
}
