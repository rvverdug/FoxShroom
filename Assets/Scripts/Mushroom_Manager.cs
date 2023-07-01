using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mushroom_Manager : MonoBehaviour
{
    [SerializeField] 
    private GameObject _mushroomPrefab;
    
    [SerializeField] 
    private int _instances = 10;
    

    // A mushroom is randomly instantiated at the beginning
    void Start()
    {
        Instantiate(_mushroomPrefab,  new Vector3(Random.Range(-380f, 380f), 0f, Random.Range(40f, 800f)), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        //When there are less mushrooms than wanted, more mushrooms are created randomly in the terrain
        while (_instances > GameObject.FindGameObjectsWithTag("Mushroom").Length)
        {
            Instantiate(_mushroomPrefab,  new Vector3(Random.Range(-380f, 380f), 0f, Random.Range(40f, 800f)), Quaternion.identity);

        }
    }
}
