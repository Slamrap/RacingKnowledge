using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {

    public int SpawningDistance;

    public GameObject Obstacles;
    public GameObject ObstaclePrefab;

    private int NumberObstacles;
    private int offset = 100;

    // Start is called before the first frame update
    void Start() {
        //deleteAllObstacles();
        //spanwAllObstacles();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void spanwAllObstacles() {
        for (int i = 0; i < NumberObstacles; i++) {
            spanwObstacle(i * SpawningDistance + offset);
        }
    }

    private void spanwObstacle(int distance) {
        // instantiate Particle Prefab
        Vector3 obstacle_pos = new Vector3(0f, 1f, distance);
        GameObject obstacle = (GameObject)Instantiate(ObstaclePrefab, obstacle_pos, Quaternion.identity);
        obstacle.transform.SetParent(Obstacles.transform);

        SelectAnswerPanel script = obstacle.GetComponent<SelectAnswerPanel>();

        script.setPanelRandomAnswer();
        //script.setPanelRandomColor(script.AnswerIndex);
    }

    public void deleteAllObstacles() {
        foreach (Transform child in Obstacles.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void setNumberObstacles(int n) {
        NumberObstacles = n;
    }

    public int getNumberObstacles() {
        return NumberObstacles;
    }
}
