using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressSpace : MonoBehaviour
{
    public static PressSpace instance;
    
    public List<TriggerPrompt> triggers;
    public List<AudioClip> clipsPlayed;

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private AudioSource audioPlayer;

    private AudioClip currentClip;
    private bool inRange = false;

    private void Start()
    {
        instance = this;

        GameObject[] gos = GameObject.FindGameObjectsWithTag("AudioLog");

        for(int i = 0; i < gos.Length; i++)
        {
            if(gos[i] != null)
            {
                triggers.Add(gos[i].GetComponent<TriggerPrompt>());
            }
        }

        triggers.ForEach(t =>
        {
            t.onEnter += DisplayPrompt;
            t.onExit += DisablePrompt;
        });
    }

    private void Update()
    {
        bool hasBeenPlayed = clipsPlayed.Contains(currentClip);
        if (Input.GetButton("Jump") && inRange && !hasBeenPlayed && !audioPlayer.isPlaying)
        {
            Debug.Log("Button pressed");
            audioPlayer.clip = currentClip;
            audioPlayer.Play();
            clipsPlayed.Add(currentClip);
            text.enabled = false;
        }
    }

    void DisplayPrompt(AudioClip clip)
    {
        if (clipsPlayed.Contains(clip)) {
            return;
        }
        inRange = true;
        text.enabled = true;
        currentClip = clip;
    }

    void DisablePrompt()
    {
        inRange = false;
        text.enabled = false;
    }
}
