using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WalkTrigger : MonoBehaviour
{

    public event Action<AudioClip> onEnter;
    public event Action onExit;

    [SerializeField] private AudioClip audioLogName;

    private void OnTriggerEnter(Collider other)
    {
        if (audioLogName == null)
        {
            Debug.Log("Missing Walk Log Name on Walk Trigger Script");
            return;
        }
        onEnter?.Invoke(audioLogName);
    }

    private void OnTriggerExit(Collider other)
    {
        if (audioLogName == null)
        {
            Debug.Log("Missing Walk Log Name on Walk Trigger Script");
            return;
        }
        onExit?.Invoke();
    }

}
