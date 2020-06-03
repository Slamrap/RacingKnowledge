using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    public Slider slider;
    public Color BackgroundColor;
    public Color BarColor;

    public Sprite FullStar;
    public Sprite OutlineStar;

    public RectTransform[] Stars;

    public void SetValue(int value) {
        slider.value = value;
    }

    public void SetMaxValue(int max_value) {
        slider.maxValue = max_value;
    }

    public void SetBackgroundColor(Color color) {
        transform.Find("Background").gameObject.GetComponent<Renderer>().material.color = color;
    }

    public void SetBarColor(Color color) {
        transform.Find("Bar").gameObject.GetComponent<Renderer>().material.color = color;
    }

    public void SetStarsPosition(int n) {
        Vector2 starPos = transform.GetComponent<RectTransform>().sizeDelta;
        Debug.Log(starPos);
        float barSize = transform.GetComponent<RectTransform>().rect.width;
        //Vector3 newPosition = new Vector3(barSize, );
        //star.position = newPosition;

        int partition = (int)Math.Ceiling((double)barSize /3);
        //Debug.Log("---->" + partition.ToString());
        for (int i = 0; i < Stars.Length; i++){
            Vector3 newPosition = new Vector3((i+1)*partition, Stars[i].localPosition.y, Stars[i].localPosition.z);
            Stars[i].localPosition = newPosition;
            //Debug.Log("Start" + i.ToString() + ": " + stars[i].ToString());
        }
    }

    public void ActivateStar(int index) {
        //Color old = Stars[index].gameObject.GetComponent<Image>().color;
        //Color newColor = new Color(255, 255, 255, 255);
        //Stars[index].gameObject.GetComponent<Image>().color = newColor;

        Stars[index].gameObject.GetComponent<Image>().sprite = FullStar;
        Stars[index].gameObject.GetComponent<Outline>().effectDistance = new Vector2(1, 1);
    }

}
