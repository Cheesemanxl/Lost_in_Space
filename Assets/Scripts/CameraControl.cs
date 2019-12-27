using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
       
        transform.position = new Vector3(player.transform.position.x + 3, player.transform.position.y + 2, player.transform.position.z - 10);

    }
}
