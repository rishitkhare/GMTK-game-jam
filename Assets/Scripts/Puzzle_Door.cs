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
    private GameObject LevelManager;
    private LevelManagerScript LScript;
    private SpriteRenderer myRenderer;
    private BoxCollider2D myCollider;
    private Sprite[] current;
    private Animation anim;
    private int a;
    public int winNum;

    private void Start()
    {
        myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        myCollider = this.gameObject.GetComponent<BoxCollider2D>();
        current = Resources.LoadAll<Sprite>("DoorUp");
        anim = this.gameObject.GetComponent<Animation>();
        a = 1;
        if(winNum == 0)
        {
            winNum = 6;
        }
        else
        {
            LevelManager = GameObject.Find("LevelManager");
            LScript = LevelManager.GetComponent<LevelManagerScript>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(winNum == 3)
        {
            if(LScript.score >= winNum)
            {
                Invoke("changeFrame", 1 / FPS);
            }
        }
    }

    public void StartOver()
    {
        myRenderer.sprite = current[0];
        myCollider.size = new Vector2(1, 3);
        myCollider.offset = new Vector2(0, 0);
        a = 0;
        myRenderer.enabled = true;
    }

    private void changeFrame()
    {
        myRenderer.sprite = current[a];
        if(a < current.Length - 1)
        {
            a++;
            myCollider.size -= new Vector2(0, 0.125f);
            myCollider.offset += new Vector2(0, 0.0625f);
            Invoke("changeFrame", 1/FPS);
        }
        else
        {
            myRenderer.enabled = false;
        }
        
    }

    

    
    


}
