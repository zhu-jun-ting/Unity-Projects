using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer mr;
    Rigidbody rb;
    [SerializeField] float time_to_wait = 2f;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        mr.enabled = false; 

        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > time_to_wait) {
            // do something
            mr.enabled = true;
            rb.useGravity = true; 
        }
    }
}
