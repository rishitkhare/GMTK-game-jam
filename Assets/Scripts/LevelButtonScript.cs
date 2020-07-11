using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonScript : MonoBehaviour
{
    private GameObject Manager;
    private GlobalStorage storage;
    private SpriteRenderer myTexture;
    public int Level;
    public string Load;
    public Sprite lockedTexture;
    public Sprite unlocked_Texture;
    void Start()
    {
        Manager = GameObject.Find("GameManager");
        storage = Manager.gameObject.GetComponent<GlobalStorage>();
        myTexture = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(storage.unlocked >= Level)
        {
            myTexture.sprite = unlocked_Texture;
        }
        else
        {
            myTexture.sprite = lockedTexture;
        }
    }

    public void OnClick()
    {
        if(storage.unlocked >= Level)
        {
            SceneManager.LoadSceneAsync(Load);
        }
    }
}
