using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
