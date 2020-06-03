using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnd : MonoBehaviour {

    public Transform EndLevelCollider;
    public Level1 LevelScript;
    public SpawnObstacles ObstaclesScript;

    private int offset = 20;

    // Start is called before the first frame update
    void Start() {
        moveEndLevel();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void moveEndLevel() {
        float distance = LevelScript.NumberQuestions * ObstaclesScript.SpawningDistance + offset;
        Vector3 endPos = new Vector3(EndLevelCollider.position.x, EndLevelCollider.position.y, distance);
        EndLevelCollider.position = endPos;
    }
}
