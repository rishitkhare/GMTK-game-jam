using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BeginningVideo : MonoBehaviour
{
    VideoPlayer vd;
    public string sceneToLoad;
    private bool canFinish;
    // Start is called before the first frame update
    private void Awake()
    {
        vd = this.gameObject.GetComponent<VideoPlayer>();
        vd.Play();
        canFinish = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!vd.isPlaying && canFinish)
        {
            SceneManager.LoadSceneAsync(sceneToLoad);
        }

        if(vd.isPlaying)
        {
            canFinish = true;
        }
    }
    
}
