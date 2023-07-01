using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameOver : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int score) {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }

    //restart button redirects user to first game level and automatically plays game
    public void RestartButton() {
        SceneManager.LoadScene("Level1");
    }

    //exit button redirects user to main menu on start screen 
    public void ExitButton() {
        SceneManager.LoadScene("StartScreen");
    }
}
