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

    float velocityX;
    public bool grounded;
    private Rigidbody2D rb;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
        velocityX = 0;
        grounded = false;
    }

    private void FixedUpdate()
    {
        grounded = hasGroundBelow();

        if (Input.GetKey(left))
        {
            velocityX += Speed * -1;
            if (grounded)
            {
                playerSpriteRenderer.flipX = true;
            }
        }

        if (Input.GetKey(right))
        {
            velocityX += Speed;
            if (grounded)
            {
                playerSpriteRenderer.flipX = false;
            }
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
        Vector2 rayOrigin = new Vector2(transform.position.x - 0.45f, transform.position.y);
        bool sumOfThreeRays = false;

        for(int i = 0; i < 3; i ++)
        {
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, 0.55f, collidable);
            Debug.DrawRay(rayOrigin, Vector2.down, Color.green, 0.01f);

            sumOfThreeRays = sumOfThreeRays || (hit.collider != null);

            rayOrigin.x += 0.45f;
        }

        return sumOfThreeRays;
    }

    private bool wallInCurrentDirection()
    {
        //ray origin is shifted down thrice in order for a more wholistic rendering of collision
        Vector2 rayOrigin = new Vector2(transform.position.x, transform.position.y - 0.45f);
        bool resultOfThree = false;
        Vector2 rayDirection = (velocityX > 0) ? Vector2.right : Vector2.left;

        for (int i = 0; i < 3; i ++)
        {
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection, 0.52f + Mathf.Abs(velocityX) * Time.fixedDeltaTime, collidable);
            Debug.DrawRay(transform.position, rayDirection, Color.blue);

            resultOfThree = resultOfThree || (hit.collider != null);

            rayOrigin.y += 0.45f;
        }



        return resultOfThree;
    }


}