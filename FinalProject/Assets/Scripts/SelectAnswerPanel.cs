using System.Collections.Generic;
using UnityEngine;

public class SelectAnswerPanel : MonoBehaviour {

    public int AnswerIndex;
    public GameObject[] GlassPanels;
    public Color[] colors;
    public Sprite[] Animals;
    public Sprite[] GeometricShapes;

    private List<Color> usedColors = new List<Color>();
    private List<Sprite> usedImage = new List<Sprite>();

    // Start is called before the first frame update
    void Start() {
        //setPanelRandomAnswer();
        //setPanelRandomColor(AnswerIndex);
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

    public void setPanelSprite(int index, Sprite image) {
        GameObject answerPanel = GlassPanels[index];
        answerPanel.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = image;
        answerPanel.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void setPanelRandomAnimalSprite(int index) {
        GameObject answerPanel = GlassPanels[index];
        Sprite img = Animals[Random.Range(0, Animals.Length)];
        if (!usedImage.Contains(img)) {
            answerPanel.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = img;
            usedImage.Add(img);
            answerPanel.transform.GetChild(0).gameObject.SetActive(true);
        }
        else {
            setPanelRandomAnimalSprite(index);
        }
    }

    public void setPanelRandomShapesSprite(int index) {
        GameObject answerPanel = GlassPanels[index];
        Sprite img = GeometricShapes[Random.Range(0, GeometricShapes.Length)];

        if (!usedImage.Contains(img)) {
            answerPanel.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = img;
            usedImage.Add(img);
            answerPanel.transform.GetChild(0).gameObject.SetActive(true);
        }
        else {
            setPanelRandomShapesSprite(index);
        }
    }

    public void decreaseSpriteScale(int index) {
        GameObject answerPanel = GlassPanels[index];
        answerPanel.transform.GetChild(0).transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void setPanelText(int index, int result) {
        GameObject answerPanel = GlassPanels[index];
        answerPanel.transform.GetChild(0).GetComponent<TextMesh>().text = result.ToString();
        answerPanel.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void AddUsedColor(Color c) {
        usedColors.Add(c);
    }

    public void AddUsedImage(Sprite img) {
        usedImage.Add(img);
    }

    public int usedColorSize() {
        return usedColors.Count;
    }

    public int GetAnswerIndex() {
        return AnswerIndex;
    }

}
