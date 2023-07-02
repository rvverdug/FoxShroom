using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Behavior : MonoBehaviour
{
    private Player_Script _playerScript;
    private void OnTriggerEnter(Collider other)
    {
        //when a player and a mushroom collide, the player "collects" the mushroom and receives a point 
        if (other.CompareTag("Player"))
        {
            _playerScript = other.gameObject.GetComponent<Player_Script>();
            _playerScript.scoreUpdate();
            Destroy(this.gameObject);
        }
    }
}
