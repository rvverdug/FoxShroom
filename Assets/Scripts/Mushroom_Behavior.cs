using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Behavior : MonoBehaviour
{
    private Player_Script _playerScript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerScript = other.gameObject.GetComponent<Player_Script>();
            _playerScript.scoreUpdate();
            Destroy(this.gameObject);
        }
    }
}
