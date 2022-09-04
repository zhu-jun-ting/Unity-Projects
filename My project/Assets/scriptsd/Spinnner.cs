using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinnner : MonoBehaviour
{
    [SerializeField] float x_angle = 0.0f;
    [SerializeField] float y_angle = 1.0f;
    [SerializeField] float z_angle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x_angle, y_angle, z_angle);
    }
}
