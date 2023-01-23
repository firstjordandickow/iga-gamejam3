using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemytype2 : MonoBehaviour
{
    [SerializeField]private GameObject player;

    public float speed;
    public bool lookRight;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lookRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if (player.transform.position.x > transform.position.x && !lookRight)
        {
            Flip();
        }
        else if (player.transform.position.x < transform.position.x && lookRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        lookRight = !lookRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(25);
            Destroy(this.gameObject);
        }
    }
}
