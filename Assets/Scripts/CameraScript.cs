using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float xOffset;
    public float yOffset;
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
        this.gameObject.transform.position = new Vector3(Player.transform.position.x + xOffset, Player.transform.position.y + yOffset, -10);
    }
}
