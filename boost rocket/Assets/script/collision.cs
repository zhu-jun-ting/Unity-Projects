using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour {

    int total_levels;
    int cur_level;

    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;

    [SerializeField] ParticleSystem crash_particles;
    [SerializeField] ParticleSystem success_particles;


    AudioSource aus;

    bool is_transitioning = false;


    void Start()
    {
        cur_level = SceneManager.GetActiveScene().buildIndex;
        total_levels = SceneManager.sceneCountInBuildSettings;
        aus = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other) {

        if (is_transitioning) {return;}

        switch(other.gameObject.tag) {
            case "Friend":
                Debug.Log("friend object");
                break;
            case "Finish":
                Debug.Log("finish!");
                finish_sequence();
                break;
            default:
                Debug.Log("obstacle");
                crash_sequence();
                break;
        }
    }

    void crash_sequence() {
        GetComponent<movement>().enabled = false;
        crash_particles.Play();
        if(!is_transitioning) {
            aus.Stop();
            aus.PlayOneShot(crash, 0.2f);
            is_transitioning = true;
        }
        Invoke("reload_scene", 1f);
    }

    void reload_scene() {
        SceneManager.LoadScene(cur_level);
    }

    void finish_sequence() {
        GetComponent<movement>().enabled = false;
        success_particles.Play();
        if(!is_transitioning) {
            aus.Stop();
            aus.PlayOneShot(success);
            is_transitioning = true;
        }
        Invoke("load_next_scene", 1f);
    }

    void load_next_scene() {
        if(cur_level == total_levels - 1) {
            SceneManager.LoadScene(0);
        } else {
            SceneManager.LoadScene(cur_level + 1);
        }
    }
}
