using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float force_magnitude = 1000;
    [SerializeField] float force_rotation = 1000;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        process_input();
    }

    void process_input() {
        if(Input.GetKey(KeyCode.Space)) {
            Debug.Log("pressed space");
            rb.AddRelativeForce(Vector3.up * force_magnitude * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.A)) {
            process_rotation(force_rotation);
        } else if (Input.GetKey(KeyCode.D)) {
            process_rotation(-force_rotation);
        } else if (Input.GetKey(KeyCode.W)) {
            Debug.Log("pressed W");
        } else if (Input.GetKey(KeyCode.S)) {
            Debug.Log("pressed S");
        } 
        
        
    }

    private void process_rotation(float force) {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * force * Time.deltaTime);
        rb.freezeRotation = false;

    }

}
