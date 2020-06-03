using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour {
    public Rigidbody Player_rb;

    public int NumberQuestions;
    public string BaseQuestion;
    public List<string> Questions;
    public List<Color> Colors;


    public SpawnObstacles SpawnObstaclesScript;

    private string[] Answers;

    private int AnsweredQuestions = 0;

    public GameObject Obstacles;

    // Start is called before the first frame update
    void Start() {
        initPanels();
    }

    // Update is called once per frame
    void Update() {

    }

    private void initPanels() {
        SpawnObstaclesScript.deleteAllObstacles();
        SpawnObstaclesScript.setNumberObstacles(NumberQuestions);
        SpawnObstaclesScript.spanwAllObstacles();
    }

    public string GetQuestion() {
        int questionIndex = Random.Range(0, Questions.Count);

        if (Questions.Count > 0) {
            string question = BaseQuestion + " " + Questions[questionIndex];
            Debug.Log(Questions.Count);

            InitQuestionObstacle(questionIndex);

            Questions.RemoveAt(questionIndex);
            Colors.RemoveAt(questionIndex);

            AnsweredQuestions++;

            return question;
        }
        return "";
    }

    public void InitQuestionObstacle(int answerIndex) {
        // Get the obstacle according to the current answer index
        GameObject obstacle = Obstacles.transform.GetChild(AnsweredQuestions).gameObject;
        // Get the glass panels and the index of the correct panel
        GameObject[] glassPanels = obstacle.GetComponent<SelectAnswerPanel>().GlassPanels;
        int correct_answer_index = obstacle.GetComponent<SelectAnswerPanel>().AnswerIndex;

        Color answerColor = Colors[answerIndex];
        obstacle.GetComponent<SelectAnswerPanel>().AddUsedColor(answerColor);

        // color each panel according to the answer
        for (int i = 0; i < glassPanels.Length; i++) {
            if (i == correct_answer_index) {
                obstacle.GetComponent<SelectAnswerPanel>().setPanelColor(i, answerColor);

                //Debug.Log(glassPanels[i].gameObject.tag);
            }
            else {
                obstacle.GetComponent<SelectAnswerPanel>().setPanelRandomColor(i);
                //glassPanels[i].GetComponent<SelectAnswerPanel>().setPanelRandomColor(i);
            }
        }

        Debug.Log("vvvvv" + obstacle.GetComponent<SelectAnswerPanel>().usedColorSize());
    }


}
