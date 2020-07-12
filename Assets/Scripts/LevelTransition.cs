using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public string sceneToLoad;

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Col");
        if (col.gameObject.tag.Equals("Player"))
        {
            SceneManager.LoadSceneAsync(sceneToLoad);
        }
    }
}
