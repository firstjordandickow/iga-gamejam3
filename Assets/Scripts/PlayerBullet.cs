using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D bulletRb;

    [SerializeField] private GameObject player;

    [SerializeField] private AudioSource src;
    public AudioClip hit;

    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = this.GetComponent<Rigidbody2D>();
        src = this.GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player");

        if (player.GetComponent<PlayerMovement>().lookRight == true)
        {
            bulletRb.velocity = player.transform.right * bulletSpeed;
        }
        else if (player.GetComponent<PlayerMovement>().lookRight == false)
        {
            bulletRb.velocity = -player.transform.right * bulletSpeed;
            Flip();
        }

        src.Play();
    }

    private void Flip()
    {
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }

        src.PlayOneShot(hit);
        Destroy(this.gameObject);
    }
}
