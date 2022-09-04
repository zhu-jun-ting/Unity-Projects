using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    [SerializeField] float move_speed = 2.0f;
    // int y = 1;
    // int z = 1;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("whatever I want to print out hahahaha");
        // transform.Translate(x, y, z);
    }

    // Update is called once per frame
    void Update() {
       MovePlayer();
    }

    void MovePlayer() {
        float xval = Input.GetAxis("Horizontal") * Time.deltaTime * move_speed;
        float yval = Input.GetAxis("Vertical") * Time.deltaTime * move_speed;
        transform.Translate(xval, 0, yval);
    }
}
