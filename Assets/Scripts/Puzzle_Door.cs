using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DoorType
{
    Locked, Button
}
public class Puzzle_Door : MonoBehaviour
{
    public DoorType myType;
    public float FPS;
    private SpriteRenderer myRenderer;
    private BoxCollider2D myCollider;
    private Sprite[] current;
    private Animation anim;
    private int a;

    private void Start()
    {
        myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        myCollider = this.gameObject.GetComponent<BoxCollider2D>();
        current = Resources.LoadAll<Sprite>("DoorUp");
        anim = this.gameObject.GetComponent<Animation>();
        a = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void changeFrame()
    {
        myRenderer.sprite = current[a];
        if(a < current.Length - 1)
        {
            a++;
            myCollider.size -= new Vector2(0, 0.125f);
            myCollider.offset += new Vector2(0, 0.625f);
            Invoke("changeFrame", 1/FPS);
        }
        else
        {
            myRenderer.enabled = false;
        }
        
    }

    

    
    


}
