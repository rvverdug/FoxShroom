using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spider_Behavior : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 2.0f;
    private float _xPos;
    private float _zPos;
    private Vector3 _desiredPos;
    private Player_Script _playerScript;

    void Start()
    {
        // START POSITION 
        transform.position = new Vector3(Random.Range(-390f, 390f), 0f, Random.Range(20f, 800f));
        _xPos = Random.Range(-390f, 390f);
        _zPos = Random.Range(20f, 800f);
        _desiredPos = new Vector3(_xPos, 0f, _zPos);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _desiredPos, Time.deltaTime * _speed);
        if (Vector3.Distance(transform.position, _desiredPos) <= 0.01f)
        {
            _xPos = Random.Range(-390f, 390f);
            _zPos = Random.Range(20f, 800f);
            _desiredPos = new Vector3(_xPos, 0, _zPos);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerScript = other.gameObject.GetComponent<Player_Script>();
            _playerScript.takeDamage();
            Destroy(this.gameObject);
        }

    }
}