using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mushroom_Manager : MonoBehaviour
{
    [SerializeField] 
    private GameObject _mushroomPrefab;

    private int _instances;
    

    // A mushroom is randomly instantiated at the beginning of the level;
    // for the first level there are 10 and for the second 5 mushrooms on the terrain at all times
    void Start()
    {
        Instantiate(_mushroomPrefab,  new Vector3(Random.Range(-380f, 380f), 0f, Random.Range(40f, 800f)), Quaternion.identity);
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1")
        {
            _instances = 10;
        }
        if (scene.name == "Level2")
        {
            _instances = 5;
        }
    }
    void Update()
    {
        //When there are less mushrooms than wanted, more mushrooms are created randomly on the terrain
        while (_instances > GameObject.FindGameObjectsWithTag("Mushroom").Length)
        {
            Instantiate(_mushroomPrefab,  new Vector3(Random.Range(-380f, 380f), 0f, Random.Range(40f, 800f)), Quaternion.identity);

        }
    }
}
