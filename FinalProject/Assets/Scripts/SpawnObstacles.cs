using UnityEngine;

public class SpawnObstacles : MonoBehaviour {

    public int SpawningDistance;

    public GameObject Obstacles;
    public GameObject ObstaclePrefab;
    public GameObject Ramps;
    public GameObject RampPrefab;

    private int NumberObstacles;
    private int offset = 100;

    // Start is called before the first frame update
    void Start() {
        //deleteAllObstacles();
        //spanwAllObstacles();
    }

    public void spanwAllObstacles() {
        for (int i = 0; i < NumberObstacles; i++) {
            spanwObstacle(i * SpawningDistance + offset);
        }
    }

    private void spanwObstacle(int distance) {
        // instantiate Particle Prefab
        Vector3 obstacle_pos = new Vector3(0f, 0.85f, distance);
        GameObject obstacle = (GameObject)Instantiate(ObstaclePrefab, obstacle_pos, Quaternion.identity);
        obstacle.transform.SetParent(Obstacles.transform);

        Vector3 ramp_pos = new Vector3(0f, -0.8f, distance - 5);

        GameObject ramp = (GameObject)Instantiate(RampPrefab, ramp_pos, Quaternion.Euler(10f,0f,0f));
        ramp.transform.localScale = new Vector3(3.7f,1f,1f);
        ramp.transform.SetParent(Ramps.transform);

        SelectAnswerPanel script = obstacle.GetComponent<SelectAnswerPanel>();

        script.setPanelRandomAnswer();
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
