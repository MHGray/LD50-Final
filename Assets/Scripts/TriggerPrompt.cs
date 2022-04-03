using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerPrompt : MonoBehaviour
{
    public event Action<AudioClip> onEnter;
    public event Action onExit;

    [SerializeField] private AudioClip audioLogName;

    private void OnTriggerEnter(Collider other)
    {
        if(audioLogName == null)
        {
            Debug.Log("Missing Audio Log Name on Trigger Prompt");
            return;
        }
        onEnter?.Invoke(audioLogName);
    }

    private void OnTriggerExit(Collider other)
    {
        if (audioLogName == null)
        {
            Debug.Log("Missing Audio Log Name on Trigger Prompt");
            return;
        }
        onExit?.Invoke();
    }
}
