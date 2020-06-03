using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float RestartDelay = 2f;
    public Level1 LevelScript;
    public ProgressBar ProgressBar;

    public GameObject GameUI;
    private int score = 0;
    private int[] stars = new int[3];
    private bool[] starts_flag = new bool[3] { false, false, false };

    // Start is called before the first frame update
    void Start() {
        InitProgress();
        InitStars();
        GameUI.SetActive(true);
        GetNextQuestion();
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void LevelComplete() {
        Debug.Log("Level Completed!");
        GameUI.SetActive(false);
        FindObjectOfType<PlayerMovement>().StopMovements();
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver() {
        Debug.Log("Game Over!");
        Invoke("Restart", RestartDelay);
    }

    public void GetNextQuestion() {
        string question = LevelScript.GetQuestion();
        Text QuestionLabel = GameUI.transform.Find("Question").gameObject.GetComponent<Text>();
        if (question != "") {
            QuestionLabel.text = question;
        }
    }

    public void IncreaseScore() {
        score++;
        ProgressBar.SetValue(score);
        Text ScoreLabel = GameUI.transform.Find("Score").gameObject.GetComponent<Text>();
        ScoreLabel.text = "Score: " + score.ToString();
        checkStars();
    }

    public void InitProgress() {
        ProgressBar.SetMaxValue(LevelScript.NumberQuestions);
        ProgressBar.SetStarsPosition(LevelScript.NumberQuestions);
    }

    public void InitStars() {
        int partition = (int)Math.Ceiling((double)LevelScript.NumberQuestions / 3);
        for (int i = 0; i < stars.Length; i++) {
            stars[i] = (i + 1) * partition;
            //Debug.Log("Start" + i.ToString() + ": " + stars[i].ToString());
        }
    }

    public void checkStars() {
        for (int i = 0; i < stars.Length; i++) {
            if (score == stars[i] && starts_flag[i] == false) {
                ProgressBar.ActivateStar(i);
                Debug.Log("Reached Star" + (i+1).ToString());
                starts_flag[i] = true;
            }
        }
    }

}
