using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Manager : MonoBehaviour
{
    [SerializeField] 
    private GameObject _spiderPrefab;

    [SerializeField] 
    private int _instances = 5;
    

    // A mushroom is randomly instantiated at the beginning
    void Start()
    {
        Instantiate(_spiderPrefab,  new Vector3(Random.Range(-380f, 380f), 0f, Random.Range(40f, 800f)), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        //When there are less mushrooms than wanted, more mushrooms are created randomly in the terrain
        while (_instances > GameObject.FindGameObjectsWithTag("Spider").Length)
        {
            Instantiate(_spiderPrefab,  new Vector3(Random.Range(-380f, 380f), 0f, Random.Range(40f, 800f)), Quaternion.identity);

        }
    }
}
