using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public float xOffset;
    public float yOffset;
    public float max_X;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LateUpdate()
    {

        this.gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);

        if(Player.transform.position.x >= max_X)
        {
            this.gameObject.transform.position = new Vector3(max_X, Player.transform.position.y + yOffset, -10);
        }
        else
        {
            this.gameObject.transform.position = new Vector3(Player.transform.position.x + xOffset, Player.transform.position.y + yOffset, -10);
        }

    }
}
