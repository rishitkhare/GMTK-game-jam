using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStorage : MonoBehaviour
{
    public int numberAbilities;
    public string[] abilities;
    public int unlocked;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        abilities = new string[numberAbilities];
        unlocked = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
