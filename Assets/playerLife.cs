using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private GameMaster gm;

    [SerializeField] private float boostForce = 15f;

    private static Vector2 lastCheckpoint = new Vector2(-5.44f, -3.16f);


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<GameMaster>();

        gameObject.GetComponent<SpriteRenderer>().color = gm.getSkin();

    }

    private void OnCollisionEnter2D(Collision2D other)
    
    {

        if (other.gameObject.CompareTag("Trap"))
        {
            Debug.Log("death");
            Die();

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {

            Debug.Log("CP");
            lastCheckpoint = other.transform.position;
            

        }

         if (other.gameObject.CompareTag("Boost")){

            rb.velocity = new Vector2(rb.velocity.x, boostForce); 

        }

        if (other.gameObject.CompareTag("Endpoint")){

            rb.velocity = new Vector2(rb.velocity.x, boostForce); 
            gm.finish();

        }

    }
    
    

    private void Die(){

        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        anim.ResetTrigger("respawn");
    
    }


    //does not get called here, but at the end of death animation
    private void RestartLevel(){


        transform.position = lastCheckpoint + new Vector2(0f, 0f);        
        rb.bodyType = RigidbodyType2D.Dynamic;
        anim.ResetTrigger("death");
        anim.SetTrigger("respawn");
        

    }

}
