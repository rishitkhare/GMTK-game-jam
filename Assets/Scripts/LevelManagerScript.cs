using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public GameObject Player;
    private PlatformingScript PlayerCont;
    public int score = 0;
    public GameObject[] Objects;
    public string[] abilities;

    void Start()
    {
        PlayerCont = Player.gameObject.GetComponent<PlatformingScript>();
        int abl = Random.Range(0, abilities.Length);
        if(abilities[abl].Equals("J"))
        {
            PlayerCont.jumpMultiplier = 1.8f;
        }
        else if(abilities[abl].Equals("S"))
        {
            PlayerCont.Speed = 4;
        }
    }

    
    void Update()
    {
        
    }

    public void startOver()
    {
        score = 0;
        for(int i = 0; i < Objects.Length; i++)
        {
            GameObject current = Objects[i];
            if(current.tag.Equals("Door"))
            {
                Puzzle_Door door = current.gameObject.GetComponent<Puzzle_Door>();
                door.Invoke("StartOver", 0);
            }
            else if(current.tag.Equals("Button"))
            {
                Puzzle_Button button = current.gameObject.GetComponent<Puzzle_Button>();
                button.Invoke("startOver",0);
            }
            else if(current.tag.Equals("Treasure"))
            {
                TreasureScript treasure = current.gameObject.GetComponent<TreasureScript>();
                treasure.Invoke("startOver", 0);
            }
        }
    }
}
