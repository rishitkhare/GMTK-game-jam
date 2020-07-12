using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Button : MonoBehaviour
{
    public GameObject myDoor;
    private Puzzle_Door myDoorScript;
    private SpriteRenderer myRenderer;
    private BoxCollider2D myCollider;
    private Sprite[] anim;
    private BoxCollider2D myCollider;
    private int i;
    private bool pressed;
    public float FPS;


    void Start()
    {
        myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        myCollider = this.gameObject.GetComponent<BoxCollider2D>();
        myDoorScript = myDoor.gameObject.GetComponent<Puzzle_Door>();
        myCollider = this.gameObject.GetComponent<BoxCollider2D>();
        pressed = false;

        anim = Resources.LoadAll<Sprite>("ButtonDown");
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            i = 0;
            Invoke("changeFrame", 1 / FPS);
        }
    }

    private void changeFrame()
    {
        myRenderer.sprite = anim[i];
        if(i < anim.Length-1)
        {
            i++;
            myCollider.size -= new Vector2(0, 0.1f);
            Invoke("changeFrame", 1 / FPS);
        }
        else
        {
            myDoorScript.Invoke("changeFrame", 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!pressed)
        {
            i = 0;
            pressed = true;
            Invoke("changeFrame", 1 / FPS);
        }

    }

    public void startOver()
    {
        myRenderer.sprite = anim[0];
        myCollider.size = new Vector2(1, 0.5f);
        pressed = false;
    }
}
