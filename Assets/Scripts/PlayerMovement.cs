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
    public int pickup1Counter;
    public int pickup2Counter;
/*    public int pickup3Counter;*/
    public TextMeshProUGUI pickupText1;
    public TextMeshProUGUI pickupText2;
/*    public TextMeshProUGUI pickupText3;*/


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
}
