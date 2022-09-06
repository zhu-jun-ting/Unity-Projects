using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    Rigidbody rb;
    AudioSource aus;
    [SerializeField] float force_magnitude = 1000;
    [SerializeField] float force_rotation = 1000;
    [SerializeField] AudioClip thrust;

    [SerializeField] ParticleSystem left_particles;
    [SerializeField] ParticleSystem right_particles;
    [SerializeField] ParticleSystem jet_particles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aus = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {        
        process_thrust();
        process_input();

    }

    void process_input() {
         if (Input.GetKey(KeyCode.A)) {
            process_rotation(force_rotation);
            play_left_particle();
        } else if (Input.GetKey(KeyCode.D)) {
            process_rotation(-force_rotation);
            play_right_particle();
        } else if (Input.GetKey(KeyCode.W)) {
            Debug.Log("pressed W");
        } else if (Input.GetKey(KeyCode.S)) {
            Debug.Log("pressed S");
        } else {
            stop_all_particles();
        }
        
        // add a comment
    }

    void play_left_particle() {
        if(!left_particles.isPlaying) {left_particles.Play();}
        if(right_particles.isPlaying) {right_particles.Stop();}
    }

    void play_right_particle() {
        if(!right_particles.isPlaying) {right_particles.Play();}
        if(left_particles.isPlaying) {left_particles.Stop();}
    }

    void process_thrust() {
        if(Input.GetKey(KeyCode.Space)) {
            Debug.Log("pressed space");
            play_sound();
            if(!jet_particles.isPlaying) {jet_particles.Play();}
            rb.AddRelativeForce(Vector3.up * force_magnitude * Time.deltaTime);
        } else {
            stop_sound();
            if(jet_particles.isPlaying) {jet_particles.Stop();}
        }
    }

    private void stop_all_particles() {
        left_particles.Stop();
        right_particles.Stop();
    }

    private void process_rotation(float force) {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * force * Time.deltaTime);
        rb.freezeRotation = false;
    }

    private void play_sound() {
        if (!aus.isPlaying) {
            aus.PlayOneShot(thrust);
        }
    }

    private void stop_sound() {
        if (aus.isPlaying) {
            aus.Stop();
        }
    }

}
