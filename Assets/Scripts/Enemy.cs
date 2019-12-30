using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    public float speed = 6;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, player.transform.position) < 8)
        {
            rb.MovePosition(Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime));
        }
    }
}
