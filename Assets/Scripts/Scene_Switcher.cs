using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Switcher : MonoBehaviour
{
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Explanation1" && Input.GetKey("space"))
        {
            SceneManager.LoadScene("Level1");
        }
        if (scene.name == "Explanation2" && Input.GetKey("space"))
        {
            SceneManager.LoadScene("Level2");
        }


    }

}
