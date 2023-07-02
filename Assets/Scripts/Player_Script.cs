using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Script : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody RB;
    
    private Animator _animator;
    private Scene _scene; 

    [SerializeField] 
    private float _speed = 5f;

    private int _score = 0;
    private int _lives = 3;
    public bool _alive = true; 
    
    [SerializeField]
    private UI_Manager _uiManager;
    
    

    

    void Start()
    {
        _animator = GetComponent<Animator>();
        _scene = SceneManager.GetActiveScene();
        // START POSITION 
        transform.position = new Vector3(0f, 0f, 25f);

    }


    void Update()
    {
        Move();
        
    }

    //The player can move forward, backward, left and right (including animations)
    private void Move()
    {
        if (Input.GetKey("up"))
        {
            
            RB.MovePosition(transform.position + new Vector3(0f,0f,5f) * Time.deltaTime * _speed);
            _animator.SetBool("_back", false);
            _animator.SetBool("_left", false);
            _animator.SetBool("_right", false);
            _animator.SetBool("_front", true);
        }
        if (Input.GetKey("down"))
        {
            RB.MovePosition(transform.position + new Vector3(0f,0f,-5f) * Time.deltaTime * _speed);
            _animator.SetBool("_front", false);
            _animator.SetBool("_left", false);
            _animator.SetBool("_right", false);
            _animator.SetBool("_back", true);
        }
        if (Input.GetKey("left"))
        {
            RB.MovePosition(transform.position + new Vector3(-5f,0f,0f) * Time.deltaTime * _speed);
            _animator.SetBool("_front", false);
            _animator.SetBool("_back", false);
            _animator.SetBool("_right", false);
            _animator.SetBool("_left", true);
        }
        if (Input.GetKey("right"))
        {
            RB.MovePosition(transform.position + new Vector3(5f,0f,0f) * Time.deltaTime * _speed);
            _animator.SetBool("_front", false);
            _animator.SetBool("_back", false);
            _animator.SetBool("_left", false);
            _animator.SetBool("_right", true);
        }


        // the player has boundaries, they cannot move out of 
        if (transform.position.x <= -380f)
        {
            transform.position = new Vector3(-375f, 0, transform.position.z);
        }
        if (transform.position.x >= 380f)
        {
            transform.position = new Vector3(375f, 0, transform.position.z);
        }
        if (transform.position.z <= 25f)
        {
            transform.position = new Vector3(transform.position.x, 0, 30f);
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
    

    //when the player collects a mushroom, their score goes up
    public void scoreUpdate()
    {
        _score += 1;
        _uiManager.scoreText(_score);
        _uiManager.sceneChange(_score, _alive);

        
    }

    //when the player gets attacked by a spider, they lose a life; if they have no lives left, the game is over
    public void takeDamage()
    {
        _lives -= 1;
        _uiManager.livesText(_lives);
        if (_lives == 0)
        {
            _alive = false;
            _uiManager.sceneChange(_score, _alive);
        }
    }
    
}
