using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb; 

    private BoxCollider2D coll;
    private Animator anim;
    private float dirX = 0;
    private SpriteRenderer sprite;

    private float moveSpeed = 6f;
     private float jumpForce = 16.3f;
    private float initjumpForce = 15f;


    private float jumpTime;
    private float jumpStartTime = 0.5f;
    private bool isJumping;
    


    private bool canJump;

    private enum MovementState{ idle, jumping}

    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    private void Update()
    {

        //dirX = Input.GetAxisRaw("Horizontal");
        //dirX = 10;

        rb.velocity = new Vector2( moveSpeed, rb.velocity.y);



        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            isJumping = true;
            jumpTime = jumpStartTime;
            rb.velocity += new Vector2(0, jumpForce * Time.deltaTime ); 

        }

        if (isJumping == true)
        {
            if (jumpTime > 0)
            {
            rb.velocity += new Vector2(0, jumpForce * Time.deltaTime ); 
            jumpTime -= Time.deltaTime;
            }

            else{

                isJumping = false;
            }

        if (Input.GetButtonUp("Jump") ){

            isJumping = false;

        }

        }

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    
    {

        MovementState state = MovementState.idle;

        if (IsGrounded() == false){

            state = MovementState.jumping;

        }

        anim.SetInteger("state", (int)state);

    }

    private bool IsGrounded()
    {


        //return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);


        var hitData = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);

        if (hitData.collider == null){

            return false;
        }


        var vec = hitData.point - new Vector2(transform.position.x, transform.position.y);

        vec = vec.normalized;

        if (vec.y < -0.95){

            return true;

        }


        return false;


        

    }


}
