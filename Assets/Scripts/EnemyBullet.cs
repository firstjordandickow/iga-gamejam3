using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D bulletRb;

    [SerializeField]private GameObject player;

    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = this.GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");

        Vector2 direction = player.transform.position - transform.position;

        bulletRb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(25);
        }

        Destroy(this.gameObject);
    }
}
