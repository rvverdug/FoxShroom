using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    [SerializeField]
    private Animator _animator = new Animator();

    [SerializeField] 
    private Rigidbody RB;

    [SerializeField] 
    private float _speed = 5f;

    private int _score = 0;
    private int _lives = 3;
    public bool _alive = true; 
    
    [SerializeField]
    private UI_Manager _uiManager;

    
    // Start is called before the first frame update
    void Start()
    {
        // START POSITION 
        transform.position = new Vector3(0f, 0f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    private void Move()
    {
        if (Input.GetKey("up"))
        {
            
            RB.MovePosition(transform.position + new Vector3(0f,0f,5f) * Time.deltaTime * _speed);
        }
        if (Input.GetKey("down"))
        {
            RB.MovePosition(transform.position + new Vector3(0f,0f,-5f) * Time.deltaTime * _speed);
        }
        if (Input.GetKey("left"))
        {
            RB.MovePosition(transform.position + new Vector3(-5f,0f,0f) * Time.deltaTime * _speed);
        }
        if (Input.GetKey("right"))
        {
            RB.MovePosition(transform.position + new Vector3(5f,0f,0f) * Time.deltaTime * _speed);
        }


        if (transform.position.x <= -380f)
        {
            transform.position = new Vector3(-375f, 0, transform.position.z);
        }
        if (transform.position.x >= 380f)
        {
            transform.position = new Vector3(375f, 0, transform.position.z);
        }
        if (transform.position.z <= 10f)
        {
            transform.position = new Vector3(transform.position.x, 0, 15f);
        }
        if (transform.position.z >= 800f)
        {
            transform.position = new Vector3(transform.position.x, 0, 795f);
        }

        if (transform.position.y < 0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }
    }
    

    public void scoreUpdate()
    {
        _score += 1;
        _uiManager.scoreText(_score);
    }

    public void takeDamage()
    {
        _lives -= 1;
        _uiManager.livesText(_lives);
        if (_lives == 0)
        {
            _alive = false;
        }
    }
    
}
