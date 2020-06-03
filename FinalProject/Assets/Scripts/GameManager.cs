using KartGame.KartSystems;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject Player; 
    public float RestartDelay = 2f;
    public Level LevelScript;
    public ProgressBar ProgressBar;
    public SpawnEnd SpawnEndScript;

    public GameObject GameUI;
    public GameObject StartGameMenu;
    public GameObject FinishGameMenu;
    public GameObject GameOverMenu;

    public Text QuestionLabel;

    public Transform[] GameOverStars;
    public Text GameOverScore;
    public Text FinishGameScore;

    private int score = 0;
    private int[] stars = new int[3];
    private bool[] starts_flag = new bool[3] { false, false, false };

    private static bool hasBeenLoaded = false;

    private void Awake() {
        if (hasBeenLoaded ) {
            StartGameMenu.SetActive(false);
            InitLevel();
        }
    }

    public void InitLevel() {
        hasBeenLoaded = true;
        SpawnEndScript.moveEndLevel();
        LevelScript.initPanels();
        InitProgress();
        InitStars();
        GameUI.SetActive(true);
        GetNextQuestion();
        Player.GetComponent<ArcadeKart>().enabled = true;
    }

    public void LevelComplete() {
        //Debug.Log("Level Completed!");
        Invoke("OpenFinishGameMenu", 1f);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMainMenu() {
        hasBeenLoaded = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver() {
        //Debug.Log("Game Over!");
        Invoke("OpenGameOverMenu", 2f);
    }

    public void GetNextQuestion() {
        string question = LevelScript.GetQuestion();
        if (question != "") {
            QuestionLabel.text = question;
        }
    }

    public void IncreaseScore() {
        score++;
        ProgressBar.SetValue(score);

        GameOverScore.text = score.ToString();
        FinishGameScore.text = score.ToString();

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
        }
    }

    public void checkStars() {
        for (int i = 0; i < stars.Length; i++) {
            if (score == stars[i] && starts_flag[i] == false) {
                ProgressBar.ActivateStar(i);
                starts_flag[i] = true;
                GameOverStars[i].gameObject.SetActive(true);
            }
        }
    }

    public void HidePlayer() {
        Player.SetActive(false);
    }

    public void OpenGameOverMenu() {
        GameUI.SetActive(false);
        FinishGameMenu.SetActive(false);
        GameOverMenu.SetActive(true);
        Player.SetActive(false);
    }

    public void OpenFinishGameMenu() {
        GameUI.SetActive(false);
        GameOverMenu.SetActive(false);
        FinishGameMenu.SetActive(true);
        Player.SetActive(false);
    }

}
