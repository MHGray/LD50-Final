using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class BossTrigger : MonoBehaviour
{
    public event Action onEnter;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private Transform target;
    [SerializeField] private SceneController sceneController;

    private void Awake()
    {
        director.played += DirectorPlayed;
        director.stopped += DirectorStopped;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Player Entered Trigger");
            other.GetComponent<PlayerMove>().enabled = false;
            other.GetComponentInChildren<MouseLook>().enabled = false; 
            other.GetComponentInChildren<LookAtTarget>().enabled = true; 
            onEnter?.Invoke();
            director.Play();
        }
    }

    private void DirectorPlayed(PlayableDirector obj)
    {

    }


    private void DirectorStopped(PlayableDirector obj)
    {
        sceneController.loadScene("MainMenu");
        Cursor.lockState = CursorLockMode.Confined;
    }
}
