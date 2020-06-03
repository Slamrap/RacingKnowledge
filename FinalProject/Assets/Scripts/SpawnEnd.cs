using UnityEngine;

public class SpawnEnd : MonoBehaviour {

    public Transform EndLevelCollider;
    public Level LevelScript;
    public SpawnObstacles ObstaclesScript;

    private int offset = 40;

    // Start is called before the first frame update
    void Start() {
        //moveEndLevel();
    }

    public void moveEndLevel() {
        float distance = LevelScript.NumberQuestions * ObstaclesScript.SpawningDistance + offset;
        Vector3 endPos = new Vector3(EndLevelCollider.position.x, EndLevelCollider.position.y, distance);
        EndLevelCollider.position = endPos;
    }
}
