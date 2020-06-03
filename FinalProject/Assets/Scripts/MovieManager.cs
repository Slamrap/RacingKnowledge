using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieManager : MonoBehaviour {

    public Camera MainCamera;
    public Camera NewCameraAngle;

    public GameObject Interface;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("space")) {
            MainCamera.enabled = !MainCamera.enabled;
            NewCameraAngle.enabled = !NewCameraAngle.enabled;

            if (Interface.activeSelf)
                Interface.SetActive(false);
            else
                Interface.SetActive(true);
        }
    }
}
