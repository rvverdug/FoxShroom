using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{


    [SerializeField] 
    private TextMeshProUGUI _scoretext;
    [SerializeField] 
    private TextMeshProUGUI _livestext;

    public void scoreText(int _score)
    {
        _scoretext.text = "Score: " + _score;
    }
    
    public void livesText(int _lives)
    {
        _livestext.text = "Lives: " + _lives;
    }

    public void sceneChange(bool _alive)
    {
        Scene scene = SceneManager.GetActiveScene();
        //if the player is still alive, the game goes on or they have won
        if (_alive == true)
        {
            if (scene.name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            if (scene.name == "Level2")
            {
                SceneManager.LoadScene("WinningScreen");
            }
        }
        // if the player has died, it's game over
        if (_alive == false)
        {
            SceneManager.LoadScene("Game_Over_Screen");
        }
    }

}
