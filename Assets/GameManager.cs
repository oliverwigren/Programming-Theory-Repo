using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int fallbackTotalScore;
    public int totalScore {
        get
        {
            return totalScore;
        }
        set 
        {
            if (value < 0) { Debug.LogError("score cannot be a negative number"); }
            else { fallbackTotalScore = value; }
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
        if (SaveManager.Instance.name == null)
        {
            Debug.LogWarning("No Bakery-name was found, default name will be used");
            titleText.text = "Bakery";
        }
        else
        {
        titleText.text = SaveManager.Instance.name;
        }
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        scoreText.text = "SCORE: 0";
    }

    public void UpdateScore(int addition)
    {
        totalScore -= addition;
        scoreText.text = "SCORE: " + fallbackTotalScore;
    }
}
