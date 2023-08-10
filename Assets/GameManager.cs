using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int totalScore { set
        {
            if (value < 0) { Debug.LogError("score cannot be a negative number");}
        } 
    } 
    private Text titleText;
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        SetUI();
    }

    private void SetUI()
    {
        titleText = GameObject.Find("Title").GetComponent<Text>();
        SaveManager.Instance.LoadName();
        titleText.text = SaveManager.Instance.name;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = "SCORE: 0";
    }

    public void UpdateScore(int addition)
    {
        totalScore += addition;
        scoreText.text = "SCORE: " + totalScore;
    }
}
