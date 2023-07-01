using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spider_Manager : MonoBehaviour
{
    [SerializeField] 
    private GameObject _spiderPrefab;

    private int _instances;
    

    // One spider is randomly instantiated at the beginning
    // for the first level there are 6 and for the second 10 spiders on the terrain at all times
    void Start()
    {
        Instantiate(_spiderPrefab,  new Vector3(Random.Range(-380f, 380f), 0f, Random.Range(40f, 800f)), Quaternion.identity);
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1")
        {
            _instances = 6;
        }
        if (scene.name == "Level2")
        {
            _instances = 10;
        }

    }


    void Update()
    {
        //When there are less spiders than wanted, more spiders are created randomly on the terrain
        while (_instances > GameObject.FindGameObjectsWithTag("Spider").Length)
        {
            Instantiate(_spiderPrefab,  new Vector3(Random.Range(-380f, 380f), 0f, Random.Range(40f, 800f)), Quaternion.identity);

        }
    }
}
