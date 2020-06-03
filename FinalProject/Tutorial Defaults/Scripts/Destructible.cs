﻿using UnityEngine;

public class Destructible : MonoBehaviour {

    public GameObject BrokenGlassPrefab;

    private void OnCollisionEnter(Collision collision){
        if (collision.collider.tag == "Player" && gameObject.tag == "Glass") {
            Vector3 col_pos = transform.position;
            int[] angles = new int[] { 90, -90, 180, -180 };
            int newAngle = angles[Random.Range(0, angles.Length)];
            Color glassPaneColor = gameObject.GetComponent<Renderer>().material.color;
            //Vector3 new_Rotation = new Vector3(0, 0, angles[Random.Range(0, angles.Length)]);
            Destroy(gameObject);
            Instantiate(BrokenGlassPrefab, col_pos, transform.rotation * Quaternion.Euler(0f, 0f, newAngle));
            //BrokenGlassPrefab.GetComponent<Renderer>().material.color = glassPaneColor;

            for (int i = 0; i < BrokenGlassPrefab.transform.childCount; i++) {
                BrokenGlassPrefab.transform.GetChild(i).GetComponent<Renderer>().sharedMaterial.color = glassPaneColor;
            }
        }
    }
}
