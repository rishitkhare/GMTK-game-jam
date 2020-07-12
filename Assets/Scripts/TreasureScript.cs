using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour
{
    public Sprite[] anim;
    public GameObject LevelManager;
    private LevelManagerScript LScript;
    private SpriteRenderer myRenderer;
    private bool opened = false;
    
    void Start()
    {
        myRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        LScript = LevelManager.gameObject.GetComponent<LevelManagerScript>();
        myRenderer.sprite = anim[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!opened)
        {
            myRenderer.sprite = anim[anim.Length - 1];
            opened = true;
            LScript.score++;
        }
    }

    public void startOver()
    {
        myRenderer.sprite = anim[0];
    }
}
