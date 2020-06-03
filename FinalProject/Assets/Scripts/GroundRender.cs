using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRender : MonoBehaviour {

    public Transform Ground;
    //public Transform Water;
    public Transform Environment;
    public Transform Player;

    private float offset = 70;

    // Update is called once per frame
    void Update() {
        Ground.position = new Vector3(Ground.position.x, Ground.position.y, Player.position.z + offset);
        //Water.position = new Vector3(Water.position.x, Water.position.y, Player.position.z + offset);
        Environment.position = new Vector3(Environment.position.x, Environment.position.y, Player.position.z);
    }
}
