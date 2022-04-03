using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAudioTrigger : MonoBehaviour
{
    public static PassiveAudioTrigger instance;

    public List<WalkTrigger> triggers;
    public List<AudioClip> clipsPlayed;

    [SerializeField] private AudioSource audioPlayer;

    private AudioClip currentClip;

    private void Start()
    {
        instance = this;

        GameObject[] gos = GameObject.FindGameObjectsWithTag("WalkLog");

        for (int i = 0; i < gos.Length; i++)
        {
            if (gos[i] != null)
            {
                triggers.Add(gos[i].GetComponent<WalkTrigger>());
            }
        }

        triggers.ForEach(t =>
        {
            t.onEnter += playAudio;
        });
    }

    public void Update()
    {
        if(currentClip != null && !audioPlayer.isPlaying)
        {
            audioPlayer.clip = currentClip;
            clipsPlayed.Add(currentClip);
            currentClip = null;
            audioPlayer.Play();
        }
    }

    public void playAudio(AudioClip clip)
    {
        bool alreadyPlayed = clipsPlayed.Contains(clip);
        if ( alreadyPlayed || currentClip != null)
        {
            return;
        }
        currentClip = clip;
    }

}
