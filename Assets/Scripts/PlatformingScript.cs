using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformingScript : MonoBehaviour
{
    public float Speed;
    public float jumpMultiplier;
    public KeyCode jump;
    public KeyCode left;
    public KeyCode right;
<<<<<<< Updated upstream
    private bool grounded;
=======
    public LayerMask collidable;
    public SpriteRenderer playerSpriteRenderer;
    public Vector2 size = new Vector2(1,1);
    public Vector2 respawnCoords;
    public GameObject LevelManager;

    float velocityX;
    public bool grounded;
>>>>>>> Stashed changes
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
        grounded = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(left))
        {
            rb.velocity = new Vector2(Speed * -1, rb.velocity.y);
        }

        if(Input.GetKey(right))
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
        }

        if (Input.GetKey(jump) && grounded)
        {
            grounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpMultiplier);
        }

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Respawn"))
        {
            LevelManagerScript Manager = LevelManager.gameObject.GetComponent<LevelManagerScript>();
            Manager.startOver();
            this.transform.position = new Vector3(respawnCoords.x, respawnCoords.y, 0);
        }
    }


}
