using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public enum LevelsNames{ ColorLevel, AnimalsLevel, ShapesLevel, MathsLevel};
    public LevelsNames LevelSelector;
    [Space]
    [Header("Questions Section")]
    public int NumberQuestions;
    public string BaseQuestion;
    public List<string> Questions;
    [Header("Answers Section")]
    public List<Color> Colors;
    [Header("Answers Section")]
    public List<Sprite> Animals;
    [Header("Answers Section")]
    public List<Sprite> GeometricShapes;

    [Space]
    public SpawnObstacles SpawnObstaclesScript;
    public GameObject Obstacles;

    private string[] Answers;
    private int AnsweredQuestions = 0;

    // Start is called before the first frame update
    void Start() {
        //initPanels();
    }

    public void initPanels() {
        SpawnObstaclesScript.deleteAllObstacles();
        SpawnObstaclesScript.setNumberObstacles(NumberQuestions);
        SpawnObstaclesScript.spanwAllObstacles();
    }

    public string GetQuestion() {
        //Debug.Log(LevelSelector);
        string question = "";

        switch (LevelSelector) {
            case LevelsNames.ColorLevel:
                question = GetColorQuestion();
                break;
            case LevelsNames.AnimalsLevel:
                question = GetAnimalQuestion();
                break;
            case LevelsNames.ShapesLevel:
                question = GetGeometricShapesQuestion();
                break;
            case LevelsNames.MathsLevel:
                question = GetMathsQuestion();
                break;
        }
        return question;
    }

    public string GetColorQuestion() {
        int questionIndex = Random.Range(0, Questions.Count);
        if (Questions.Count > 0) {
            string question = BaseQuestion + " " + Questions[questionIndex] + "?";
            //Debug.Log(Questions.Count);
            InitColorQuestionObstacle(questionIndex);
            Questions.RemoveAt(questionIndex);
            Colors.RemoveAt(questionIndex);
            AnsweredQuestions++;
            return question;
        }
        return "";
    }

    public string GetAnimalQuestion() {
        int questionIndex = Random.Range(0, Questions.Count);
        if (Questions.Count > 0) {
            string question = BaseQuestion + " " + Questions[questionIndex] + "?";
            //Debug.Log(Questions.Count);
            InitImageQuestionObstacle(questionIndex, Animals);
            Questions.RemoveAt(questionIndex);
            Animals.RemoveAt(questionIndex);
            AnsweredQuestions++;
            return question;
        }
        return "";
    }

    public string GetGeometricShapesQuestion() {
        int questionIndex = Random.Range(0, Questions.Count);
        if (Questions.Count > 0) {
            string question = BaseQuestion + " " + Questions[questionIndex] + "?";
            //Debug.Log(Questions.Count);
            InitImageQuestionObstacle(questionIndex, GeometricShapes);
            Questions.RemoveAt(questionIndex);
            GeometricShapes.RemoveAt(questionIndex);
            AnsweredQuestions++;
            return question;
        }
        return "";
    }

    public string GetMathsQuestion() {
        int questionIndex = Random.Range(0, Questions.Count);
        if (Questions.Count > 0) {
            string question = Questions[questionIndex] + " = ?";
            //Debug.Log(Questions.Count);
            InitTextQuestionObstacle(questionIndex);
            Questions.RemoveAt(questionIndex);
            AnsweredQuestions++;
            return question;
        }
        return "";
    }

    public void InitColorQuestionObstacle(int answerIndex) {
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
            }
            else {
                obstacle.GetComponent<SelectAnswerPanel>().setPanelRandomColor(i);
            }
        }
    }

    public void InitImageQuestionObstacle(int answerIndex, List<Sprite> answerSprites) {
        // Get the obstacle according to the current answer index
        GameObject obstacle = Obstacles.transform.GetChild(AnsweredQuestions).gameObject;
        
        // Get the glass panels and the index of the correct panel
        GameObject[] glassPanels = obstacle.GetComponent<SelectAnswerPanel>().GlassPanels;
        int correct_answer_index = obstacle.GetComponent<SelectAnswerPanel>().AnswerIndex;

        Sprite answerImage = answerSprites[answerIndex];
        obstacle.GetComponent<SelectAnswerPanel>().AddUsedImage(answerImage);

        // color each panel according to the answer
        for (int i = 0; i < glassPanels.Length; i++) {
            if (i == correct_answer_index) {
                obstacle.GetComponent<SelectAnswerPanel>().setPanelSprite(i, answerImage);
                obstacle.GetComponent<SelectAnswerPanel>().setPanelRandomColor(i);
                if (LevelSelector.Equals(LevelsNames.ShapesLevel))
                    obstacle.GetComponent<SelectAnswerPanel>().decreaseSpriteScale(i);
            }
            else {
                if (LevelSelector.Equals(LevelsNames.AnimalsLevel))
                    obstacle.GetComponent<SelectAnswerPanel>().setPanelRandomAnimalSprite(i);
                else if (LevelSelector.Equals(LevelsNames.ShapesLevel)) {
                    obstacle.GetComponent<SelectAnswerPanel>().setPanelRandomShapesSprite(i);
                    obstacle.GetComponent<SelectAnswerPanel>().decreaseSpriteScale(i);
                }
                obstacle.GetComponent<SelectAnswerPanel>().setPanelRandomColor(i);
            }
        }
    }

    public void InitTextQuestionObstacle(int answerIndex) {
        // Get the obstacle according to the current answer index
        GameObject obstacle = Obstacles.transform.GetChild(AnsweredQuestions).gameObject;
        // Get the glass panels and the index of the correct panel
        GameObject[] glassPanels = obstacle.GetComponent<SelectAnswerPanel>().GlassPanels;
        int correct_answer_index = obstacle.GetComponent<SelectAnswerPanel>().AnswerIndex;

        //Evaluate question
        int result = evaluateMathExpression(Questions[answerIndex]);
        List<int> OtherResults = new List<int>();
        OtherResults.Add(result - Random.Range(1, 2));
        OtherResults.Add(result + Random.Range(1, 2));

        // color each panel according to the answer
        for (int i = 0; i < glassPanels.Length; i++) {
            if (i == correct_answer_index) {
                obstacle.GetComponent<SelectAnswerPanel>().setPanelText(i, result);
                obstacle.GetComponent<SelectAnswerPanel>().setPanelRandomColor(i);
            }
            else {
                int aux_index = Random.Range(0, OtherResults.Count);
                obstacle.GetComponent<SelectAnswerPanel>().setPanelText(i, OtherResults[aux_index]);
                obstacle.GetComponent<SelectAnswerPanel>().setPanelRandomColor(i);
                OtherResults.RemoveAt(aux_index);
            }
        }
    }

    public int evaluateMathExpression(string expression) {
        int result = 0;
        string[] exp = expression.Split(' ');

        int num1 = System.Int32.Parse(exp[0]);
        int num2 = System.Int32.Parse(exp[2]);
        string operation = exp[1];

        switch (operation) {
            case "+":
                result = num1 + num2;
                break;
            case "-":
                result = num1 - num2;
                break;
            case "x":
                result = num1 * num2;
                break;
        }
        return result;
    }
}
