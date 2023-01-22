using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D bulletRb;

    [SerializeField] private GameObject player;

    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = this.GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");

        bulletRb.velocity = player.transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        Destroy(this.gameObject);
    }
}
