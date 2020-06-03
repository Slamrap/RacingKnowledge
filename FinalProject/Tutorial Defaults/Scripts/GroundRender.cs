using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRender : MonoBehaviour {

    public Transform Ground;
    public Transform Water;
    public Transform Player;

    private float groundLenght;
    private float waterLenght;
    private float offset = 70;

    // Start is called before the first frame update
    void Start() {
        groundLenght = Ground.transform.localScale.z;
        waterLenght = Water.transform.localScale.z;
        
    }

    // Update is called once per frame
    void Update() {
        Ground.position = new Vector3(Ground.position.x, Ground.position.y, Player.position.z + offset);
        Water.position = new Vector3(Water.position.x, Water.position.y, Player.position.z + offset);
    }
}
