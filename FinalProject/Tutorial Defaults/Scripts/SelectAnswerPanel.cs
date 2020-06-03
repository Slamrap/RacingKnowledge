using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnswerPanel : MonoBehaviour {

    public int AnswerIndex;
    public GameObject[] GlassPanels;
    public Color[] colors;

    private List<Color> usedColors = new List<Color>();

    // Start is called before the first frame update
    void Start() {
        //setPanelRandomAnswer();
        //setPanelRandomColor(AnswerIndex);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void setup() {
        
    }

    public void setPanelAnswer(int index) {
        if (index >= 0 && index < GlassPanels.Length) {
            GameObject answerPanel = GlassPanels[index];
            //Debug.Log(answerPanel.name);
            answerPanel.tag = "Glass_CorrectAnswer";
            answerPanel.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
            answerPanel.GetComponent<BoxCollider>().isTrigger = true;
            answerPanel.GetComponent<Rigidbody>().isKinematic = true;
        }
        else
            Debug.Log("Answer index out of range!");
    }

    public void setPanelRandomAnswer() {
        AnswerIndex = Random.Range(0, GlassPanels.Length);
        setPanelAnswer(AnswerIndex);
    }

    public void setPanelColor(int index, Color color) {
        GameObject answerPanel = GlassPanels[index];
        answerPanel.GetComponent<Renderer>().material.color = color;
    }

    public void setPanelRandomColor(int index) {
        GameObject answerPanel = GlassPanels[index];
        Color color = colors[Random.Range(0, colors.Length)];

        if (!usedColors.Contains(color)){
            answerPanel.GetComponent<Renderer>().material.color = color;
            usedColors.Add(color);
        }
        else {
            setPanelRandomColor(index);
        }


    }

    public void setPanelText() {

    }

    public void setPanelSprite() {

    }

    public void AddUsedColor(Color c) {
        usedColors.Add(c);
    }

    public int usedColorSize()
    {
        return usedColors.Count;
    }

    public int GetAnswerIndex() {
        return AnswerIndex;
    }


}
