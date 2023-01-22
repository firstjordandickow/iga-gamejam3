using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    public float moveSpeed;
    public float jumpForce;

    private float moveInput;
    private Rigidbody2D rb;

    [Header("Ground Check Variables")]
    [SerializeField] bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;

    [SerializeField]private bool lookRight;

    [Header("Pickup Variables")]
    public int totalItem1;
    public int totalItem2;
    public int pickup1Counter;
    public int pickup2Counter;
    public TextMeshProUGUI pickupText1;
    public TextMeshProUGUI pickupText2;

    [Header("Shoot variables")]
    public GameObject bullet;
    public Transform bulletSpawn;
    public float timeToShoot;

    public Vector2 checkpointPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        lookRight = true;
        isGrounded = true;
    }

    private void Update()
    {
        //Get the movement input from user
        moveInput = Input.GetAxisRaw("Horizontal");


        //Flip character sprite to look left
        if(lookRight && moveInput < 0f)
        {
            FlipPlayer();
        }
        //Flip character sprite to look right
        else if(!lookRight && moveInput > 0f)
        {
            FlipPlayer();
        }

        //check if player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        
        //Jump Input
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * 2.5f * Time.deltaTime;
        }

        //Reset the player's position to a checkpoint if player is stuck or falls down
        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetPlayer();
        }

        //Player shooting code
        timeToShoot += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.F) && timeToShoot > 1f)
        {
            Instantiate(bullet, bulletSpawn.position, Quaternion.identity);
            timeToShoot = 0;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void FlipPlayer()
    {
        lookRight = !lookRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    public void ResetPlayer()
    {
        this.transform.position = checkpointPosition;
    }
}
