using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D bulletRb;

    [SerializeField]private GameObject player;

    [SerializeField]private AudioSource bulletAudio;
    public AudioClip hit;

    public float bulletSpeed;

    private float bulletTime;
    // Start is called before the first frame update
    void Start()
    {
        bulletRb = this.GetComponent<Rigidbody2D>();
        bulletAudio = this.GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player");

        Vector2 direction = player.transform.position - transform.position;

        direction.Normalize();

        bulletRb.velocity = new Vector2(direction.x, direction.y) * bulletSpeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        bulletAudio.Play();
    }

    private void Update()
    {
        bulletTime += Time.deltaTime;

        if(bulletTime > 6f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(25);
            bulletAudio.PlayOneShot(hit);
            Destroy(this.gameObject);
        }
    }
}
