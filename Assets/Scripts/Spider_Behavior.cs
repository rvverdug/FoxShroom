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
    private Animator _animatorSpider;
    private Animator _animatorPlayer;
    

    void Start()
    {
        // START POSITION 
        transform.position = new Vector3(Random.Range(-390f, 390f), 0f, Random.Range(20f, 800f));
        // x and z coordinates are determined randomly for the spider's desired position
        _xPos = Random.Range(-390f, 390f);
        _zPos = Random.Range(20f, 800f);
        _desiredPos = new Vector3(_xPos, 0f, _zPos);
        _animatorSpider = GetComponent<Animator>();
    }

    void Update()
    {
        //The spider walks to the desired position
        transform.position = Vector3.Lerp(transform.position, _desiredPos, Time.deltaTime * _speed);
        _animatorSpider.SetBool("_run",true);
        // when the spider has reached its desired position it gets a new one 
        if (Vector3.Distance(transform.position, _desiredPos) <= 0.01f)
        {
            _xPos = Random.Range(-390f, 390f);
            _zPos = Random.Range(20f, 800f);
            _desiredPos = new Vector3(_xPos, 0, _zPos);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // when the spider attacks the player, the player takes damage and the spider disappears
        if (other.CompareTag("Player"))
        {
            _animatorSpider.SetTrigger("_attack");
            _animatorPlayer = other.gameObject.GetComponent<Animator>();
            _animatorPlayer.SetTrigger("_attacked");
            _playerScript = other.gameObject.GetComponent<Player_Script>();
            _playerScript.takeDamage();
            Destroy(this.gameObject);
        }

    }
}