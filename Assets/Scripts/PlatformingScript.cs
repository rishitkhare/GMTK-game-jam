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
    public LayerMask collidable;
    public SpriteRenderer playerSpriteRenderer;
    public Vector2 size = new Vector2(1,1);

    float velocityX;
    public bool grounded;
    private Rigidbody2D rb;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
        velocityX = 0;
        grounded = false;
        size.x /= 2f;
        size.y /= 2f;
    }

    private void FixedUpdate()
    {
        grounded = hasGroundBelow();

        if (Input.GetKey(left))
        {
            velocityX -= Speed;

            playerSpriteRenderer.flipX = true;
        }

        if (Input.GetKey(right))
        {
            velocityX += Speed;

            playerSpriteRenderer.flipX = false;

        }

        velocityX *= 0.85f;
        if(Mathf.Abs(velocityX) < 0.1f)
        {
            velocityX = 0;
        }

        //detect walls on x axis
        if (velocityX != 0)
        {
            if (wallInCurrentDirection())
            {
                velocityX = 0;
            }
        }
        

        transform.position = new Vector2(transform.position.x + velocityX * Time.fixedDeltaTime, transform.position.y);


        if (Input.GetKey(jump) && grounded)
        {
            grounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpMultiplier * 13f);
        }



    }


    private bool hasGroundBelow()
    {
        //ray origin is shifted right thrice in order for a more wholistic rendering of collision
        Vector2 rayOrigin = new Vector2(transform.position.x - (size.x - 0.05f), transform.position.y);
        bool sumOfThreeRays = false;

        for(int i = 0; i < 3; i ++)
        {
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, (size.y + 0.05f), collidable);
            Debug.DrawRay(rayOrigin, Vector2.down, Color.green, 0.01f);

            sumOfThreeRays = sumOfThreeRays || (hit.collider != null);

            rayOrigin.x += size.x - 0.05f;
        }

        return sumOfThreeRays;
    }

    private bool wallInCurrentDirection()
    {
        //ray origin is shifted down thrice in order for a more wholistic rendering of collision
        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - (size.y - 0.05f));
        bool resultOfThree = false;
        Vector2 rayDirection = (velocityX > 0) ? Vector2.right : Vector2.left;

        for (int i = 0; i < 3; i ++)
        {
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, (size.x + 0.02f) + Mathf.Abs(velocityX) * Time.fixedDeltaTime, collidable);
            Debug.DrawRay(transform.position, rayDirection, Color.blue);

            resultOfThree = resultOfThree || (hit.collider != null);

            rayOrigin.y += size.y - 0.05f;
        }



        return resultOfThree;
    }


}