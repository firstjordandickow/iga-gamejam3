using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoots : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;

    public GameObject player;
    public bool lookRight;

    private float cooldownTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lookRight = true;
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(player.transform.position, transform.position);

        if(player.transform.position.x > transform.position.x && !lookRight)
        {
            Flip();
        }
        else if(player.transform.position.x < transform.position.x && lookRight)
        {
            Flip();
        }

        if (distance < 20f)
        {
            if (cooldownTime > 2f)
            {
                Shoot();
            }

            cooldownTime += Time.deltaTime;
        }
    }

    private void Flip()
    {
        lookRight = !lookRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    private void Shoot()
    {
        cooldownTime = 0;
        Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
    }
}
