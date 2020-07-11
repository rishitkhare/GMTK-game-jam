using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodAI : MonoBehaviour
{
    private GameObject Manager;
    private GlobalStorage storage;
    public string myElement;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("GameManager");
        storage = Manager.gameObject.GetComponent<GlobalStorage>();
        doAction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void ApplyAbility()
    {

    }

    public void doAction()
    {
        float action = Random.Range(1, 4);
        if(myElement.Equals("Earth"))
        {
            
        }

        Debug.Log(action);
        Invoke("doAction", Random.Range(8, 20));
    }
}
