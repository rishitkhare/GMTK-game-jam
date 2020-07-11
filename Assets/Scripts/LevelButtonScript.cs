using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonScript : MonoBehaviour
{
    private GameObject Manager;
    private GlobalStorage storage;
    private Image myTexture;
    private Button myButton;
    public int Level;
    public string Load;
    public Sprite lockedTexture;
    public Sprite unlocked_Texture;
    void Start()
    {
        Manager = GameObject.Find("GameManager");
        storage = Manager.gameObject.GetComponent<GlobalStorage>();
        myTexture = this.gameObject.GetComponent<Image>();
        myButton = this.gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(storage.unlocked >= Level)
        {
            myTexture.sprite = unlocked_Texture;
            myButton.enabled = true;
        }
        else
        {
            myTexture.sprite = lockedTexture;
            myButton.enabled = false;
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
