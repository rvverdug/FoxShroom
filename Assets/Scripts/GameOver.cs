using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameOverScript : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int score) {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
    }

    public void RestartButton() {
        SceneManager.LoadScene("Scene1");
    }

    public void ExitButton() {
        SceneManager.LoadScene("StartScreen");
    }
}
