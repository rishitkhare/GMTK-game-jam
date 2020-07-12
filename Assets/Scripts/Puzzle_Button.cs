using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Button : MonoBehaviour
{
    public GameObject myDoor;
    private Puzzle_Door myDoorScript;
    private SpriteRenderer myRenderer;
    private Sprite[] anim;
    private int i;
    public float FPS;
    void Start()
    {
        myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        myDoorScript = myDoor.gameObject.GetComponent<Puzzle_Door>();
        anim = Resources.LoadAll<Sprite>("ButtonDown");
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
            Invoke("changeFrame", 1 / FPS);
        }
        else
        {
            myDoorScript.Invoke("changeFrame", 1);
        }
    }
<<<<<<< Updated upstream
    
=======

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
>>>>>>> Stashed changes
}
